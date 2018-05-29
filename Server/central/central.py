
import socket
import select
import pymysql
import datetime
import json
import threading
import uuid
import os
import sys
import time

class connected_client:
    def __init__(self, fd):
        self.fd                     = fd
        self.id                     = None

    def receive(self, size):
        try:
            return self.fd.recv(size)

        except:
            return None

    def request(self):
        try:
            json_size               = int.from_bytes(self.fd.recv(4), byteorder='little')
            json_text               = self.fd.recv(json_size).decode('utf-8')
            return json.loads(json_text)

        except:
            return None

    def response(self, content, mimetype):
        try:
            header                  = 'HTTP/1.1 200 OK\nContent-Type: {}\n\n'.format(mimetype).encode('utf-8')
            self.fd.sendall(header + content)
            return True
        except Exception as e:
            return False

    def close(self):
        self.fd.close()



class client_set:
    def __init__(self, fd):
        self.__fd = fd
        self.__dict = {}
        self.__lock = threading._allocate_lock()

    def __del__(self):
        self.clear()

    def fd_list(self):
        ret = [self.__fd]
        for fd in self.__dict:
            ret.append(fd)

        return ret

    def select(self):
        ret                                     = []

        fd_list                                 = self.fd_list();
        read_set, write_set, except_set         = select.select(fd_list, [], [], 5)
        for event_fd in read_set:
            if event_fd == sys.stdin:
                pass

            elif event_fd == self.__fd:
                ret.append(None)

            else:
                ret.append(self.__dict[event_fd])


        return ret

    def accept(self):
        fd, addr                                = self.__fd.accept()
        self.__lock.acquire()
        self.__dict[fd]                         = connected_client(fd)
        self.__lock.release()
        return self.__dict[fd]

    def remove(self, client):
        if client.fd not in self.__dict:
            return False
        
        client.close()
        self.__lock.acquire()
        del self.__dict[client.fd]
        self.__lock.release()
        return True

    def clear(self):
        for fd in self.__dict:
            self.__dict[fd].close()
        self.__lock.acquire()
        self.__dict.clear()
        self.__lock.release()

    def broadcast(self, data, excludes=None):
        self.__lock.acquire()
        for client in self.__dict.values():
            try:
                if excludes is not None and client in excludes:
                    continue

                client.fd.sendall(data)
            except:
                continue

        self.__lock.release()

    def __iter__(self):
        return self.__dict.values().__iter__()

    def __getitem__(self, key):
        return self.__dict[key]


class central_server:
    def __init__(self, port):
        self._conn                              = pymysql.connect(host='localhost', user='oyo', password='oyoteam', db='oyo', charset='utf8')
        self._cursor                            = self._conn.cursor()

        # Create socket
        self._socket                            = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self._socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
        self._socket.bind(('', port))
        self._socket.listen()

        # Connected client manager
        self._client_set                        = client_set(self._socket)


        # Streaming flag
        self._streaming                         = False

        # Thread lock member
        self._accept_thread                     = None
        self._lock                              = threading._allocate_lock()

    def __del__(self):
        print('exit from central_server')
        self._cursor.close()
        self._conn.close()
        self.exit()

    def execute(self, async):
        if self._streaming:
            return False

        self._streaming                         = True

        self._accept_thread                     = threading.Thread(target=self.accept_thread_routine)
        self._accept_thread.start()


        if not async:
            self.join()

        return True
        

    def join(self):
        if self._accept_thread is not None:
            self._accept_thread.join()
            self._accept_thread = None


        if self._socket is not None:
            self._socket.close()
            self._socket = None


    def exit(self):
        if not self._streaming:
            return False

        self._streaming                         = False
        self.join()
        return True

    def generate_filename(self, directory, prefix, ext):
        if not os.path.exists(directory):
            os.mkdir(directory)

        if not os.path.isdir(directory):
            return None

        while True:
            filename = '{}/{}_{}.{}'.format(directory, prefix, uuid.uuid4(), ext)
            if not os.path.exists(filename):
                return filename

    def accept_thread_routine(self):
        while self._streaming is True:
            event_clients                       = self._client_set.select()
            for client in event_clients:
                if client is None:
                    connected_client            = self._client_set.accept()
                    continue

                try:
                    data                        = client.request()
                    if data is None:
                        raise Exception()

                    if data['method'] == 'detected':
                        host, port              = client.fd.getpeername()

                        inf_bytes          = client.receive(int(data['images']['infrared']['size']))
                        if inf_bytes is None:
                            raise Exception()
                        inf_path                = self.generate_filename('images', 'infrared', 'jpg')
                        with open(inf_path, 'wb') as f:
                            f.write(inf_bytes)


                        vis_bytes            = client.receive(int(data['images']['visual']['size']))
                        if vis_bytes is None:
                            raise Exception()
                        vis_path                = self.generate_filename('images', 'visual', 'jpg')
                        with open(vis_path, 'wb') as f:
                            f.write(vis_bytes)


                        bnd_bytes           = client.receive(int(data['images']['blended']['size']))
                        if bnd_bytes is None:
                            raise Exception()
                        bnd_path                = self.generate_filename('images', 'blended', 'jpg')
                        with open(bnd_path, 'wb') as f:
                            f.write(bnd_bytes)

                        sql = "INSERT INTO detection (addr, lat, lon, infrared, visual, blended, date) VALUES (%s, %s, %s, %s, %s, %s, %s)"
                        self._cursor.execute(sql, (str(host), data['position']['lat'], data['position']['lon'], inf_path, vis_path, bnd_path, time.strftime('%Y-%m-%d %H:%M:%S')))
                        self._conn.commit()

                        data['images']['inf']['path']  = inf_path
                        data['images']['vis']['path']    = vis_path
                        data['images']['bnd']['path']  = bnd_path
                        data['id']                          = self._cursor.lastrowid
                        
                        json_bytes                          = json.dumps(data).encode('utf-8')
                        json_size                           = len(json_bytes)
                        exclude_clients                     = [client,]

                        self._client_set.broadcast(json_size.to_bytes(4, 'little'), exclude_clients)
                        self._client_set.broadcast(json_bytes, exclude_clients)
                        
                        self._client_set.broadcast(int(data['images']['inf']['size']).to_bytes(4, 'little'), exclude_clients)
                        self._client_set.broadcast(inf_bytes, exclude_clients)

                        self._client_set.broadcast(int(data['images']['vis']['size']).to_bytes(4, 'little'), exclude_clients)
                        self._client_set.broadcast(vis_bytes, exclude_clients)
                        
                        self._client_set.broadcast(int(data['images']['bnd']['size']).to_bytes(4, 'little'), exclude_clients)
                        self._client_set.broadcast(bnd_bytes, exclude_clients)

                    elif data['method'] == 'gets':
                        sql = "SELECT id, lat, lon, infrared, visual, blended, date FROM detection WHERE deleted = 0 ORDER BY id DESC LIMIT %s, %s"
                        count = self._cursor.execute(sql, (int(data["offset"]), int(data["count"])))

                        ret = {'success': True, 'data': []}
                        files = []
                        for element in self._cursor.fetchall():
                            id, lat, lon, infrared, visual, blended, date = element
                            item                = {}
                            item['id']          = id
                            item['position']    = {'lat': float(lat), 'lon': float(lon)}
                            item['date']        = str(date)
                            item['images']      = {'inf': {}, 'vis': {}, 'bnd': {}}

                            file                = {}
                            with open(infrared, 'rb') as f:
                                inf_bytes       = f.read()
                                file['inf']     = inf_bytes
                                item['images']['inf']['size'] = len(inf_bytes)

                            with open(visual, 'rb') as f:
                                vis_bytes       = f.read()
                                file['vis']     = vis_bytes
                                item['images']['vis']['size'] = len(vis_bytes)

                            with open(blended, 'rb') as f:
                                bnd_bytes       = f.read()
                                file['bnd']     = bnd_bytes
                                item['images']['bnd']['size'] = len(bnd_bytes)

                            files.append(file)
                            ret['data'].append(item)


                        json_bytes = json.dumps(ret).encode('utf-8')
                        json_size = len(json_bytes)
                        client.fd.sendall(json_size.to_bytes(4, 'little'))
                        client.fd.sendall(json_bytes)

                        for file in files:
                            inf_size = len(file['inf'])
                            client.fd.sendall(inf_size.to_bytes(4, 'little'))
                            client.fd.sendall(file['inf'])

                            vis_size = len(file['vis'])
                            client.fd.sendall(vis_size.to_bytes(4, 'little'))
                            client.fd.sendall(file['vis'])

                            bnd_size = len(file['bnd'])
                            client.fd.sendall(bnd_size.to_bytes(4, 'little'))
                            client.fd.sendall(file['bnd'])


                except Exception as e:
                    self._client_set.remove(client)
                    continue

        self._client_set.clear()

if __name__ == '__main__':
    c = central_server(9997)
    c.execute(async=True)

    while True:
        cmd = input('')
        if cmd.lower() == 'exit':
            break

    c.exit()