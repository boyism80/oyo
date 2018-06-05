import sys
import cv2
import numpy as np
import socket
import threading
import select

sys.path.append("../")


class webclient:
    def __init__(self, fd):
        self.fd                     = fd
        self.id                     = None

    def request(self):
        try:
            self.data               = self.fd.recv(1024).decode('utf-8')

            splitted                = self.data.split(' ')
            self.method             = splitted[0]
            self.filename           = splitted[1]

            return self.filename

        except Exception as e:
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



class webclient_set:
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
        self.__dict[fd]                         = webclient(fd)
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

    def response(self, data):
        self.__lock.acquire()
        for client in self.__dict.values():
            try:
                if client.id is None:
                    continue

                client.response(b'--frame\r\n' b'Content-Type: image/jpeg\r\n\r\n' + data + b'\r\n\r\n', 'multipart/x-mixed-replace; boundary=frame')
            except Exception as e:
                pass

        self.__lock.release()

    def __iter__(self):
        return self.__dict.values().__iter__()

    def __getitem__(self, key):
        return self.__dict[key]


class webstream:
    def __init__(self, port):

        # Create socket
        self._socket                            = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self._socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
        self._socket.bind(('', port))
        self._socket.listen()

        # Connected client manager
        self._client_set                        = webclient_set(self._socket)


        # Streaming flag
        self._streaming                         = False

        # Thread lock member
        self._accept_thread                     = None
        self._streaming_thread                  = None
        self._lock                              = threading._allocate_lock()

    def __del__(self):
        print('exit from webstream')
        self.exit()

    def execute(self, async):
        if self._streaming:
            return False

        self._streaming                         = True

        self._accept_thread                     = threading.Thread(target=self.accept_thread_routine)
        self._accept_thread.start()

        self._streaming_thread                  = threading.Thread(target=self.streaming_thread_routine)
        self._streaming_thread.start()

        if not async:
            self.join()

        return True
        

    def join(self):
        if self._accept_thread is not None:
            self._accept_thread.join()
            self._accept_thread = None

        if self._streaming_thread is not None:
            self._streaming_thread.join()
            self._streaming_thread = None

        if self._socket is not None:
            self._socket.close()
            self._socket = None


    def exit(self):
        if not self._streaming:
            return False

        self._streaming                         = False
        self.join()
        return True

    def accept_thread_routine(self):
        while self._streaming is True:
            event_clients                       = self._client_set.select()
            for client in event_clients:
                if client is None:
                    connected_client            = self._client_set.accept()
                    continue

                filename                        = client.request()
                if filename is None:
                    self._client_set.remove(client)
                    continue

                client.id                       = filename
                        

        self._client_set.clear()

    def streaming_thread_routine(self):
        current_client                          = None
        while self._streaming:
            try:
                frame                           = self.on_request()
                if frame is None:
                    continue

                ret, frame                      = cv2.imencode('.jpg', frame)
                frame_bytes                     = frame.tobytes()

                self._client_set.response(frame_bytes);

            except Exception as e:
                pass

    def on_request(self):
        return None


if __name__ == '__main__':
    pylepton_server = webstream(80)
    pylepton_server.execute()