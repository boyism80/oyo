#ifndef	__lx_im_server_h__
#define	__lx_im_server_h__

#define _CRT_SECURE_NO_WARNINGS

#ifdef _WIN32
#pragma comment(lib, "ws2_32.lib")
#include <winsock2.h>
#else
#include <sys/time.h>
#include <unistd.h>
#include <sys/select.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <netinet/in.h>
#endif

#include <fcntl.h>
#include <thread>
#include <mutex>
#include <map>
#include "lepton.h"
#include "visual.h"

#ifndef min
#define min(a, b) (((a) < (b)) ? (a) : (b))
#endif

#ifndef max
#define max(a, b) (((a) > (b)) ? (a) : (b))
#endif

namespace lx { namespace im {

class streaming_packet
{
private:
	void*					_bytes;
	size_t					_size;
	size_t					_capacity;

public:
	streaming_packet();
	~streaming_packet();

public:
	bool					set(const void* bytes, size_t size);
	bool					realloc(size_t size);
	void*					bytes();
	const void*				bytes() const;
	size_t					size() const;

public:
	static bool				encode(int frame_type, const void* bytes, int width, int height, int size, streaming_packet* packet);
};

class client
{
private:
#ifdef _WIN32
	SOCKET					_socket;
#else
	int 					_socket;
#endif
	std::vector<uint8_t>	_buffer;
	std::vector<uint8_t>	_output_buffer;
	std::mutex 				_mutex;

public:
	client(int fd);
	~client();

private:
	bool					recv(void** buffer, int size);
	static uint32_t			square(int size);

public:
	bool					send(const void* bytes, int size);
	bool					recv(void** data, int* size);
	void					close();
	bool					equals(int fd) const;
	bool					connected() const;

public:
	bool					operator == (int fd) const;
	bool					operator != (int fd) const;
	operator				int () const;
};



class client_map : private std::map<int, client*>
{
private:
	int 					_socket;
	int 					_max_fd;
	fd_set					_fdset;
	std::vector<client*>	_events;
	std::mutex				_client_mutex;

public:
	client_map();
	~client_map();

public:
	void					init(int fd);
	bool					select(client*** events, int* count);
	bool					accept();
	bool					remove(client* c);
	bool					sendall(const streaming_packet* packet);
};



class server
{
private:
	lx::lepton*				_lepton;
	lx::visual				_visual;

	int 					_socket;
	client_map				_clients;
	bool					_streaming;

	std::thread*			_accept_thread;
	std::thread*			_istreaming_thread;
	std::thread*			_vstreaming_thread;

public:
	server(int port, lx::lepton::type type = lx::lepton::type::LEPTON_25, const char* spidev = "/dev/spidev0.1", int camera_device = 0);
	~server();

public:
	bool					init(int port);
	void					release();
	bool					execute(bool async = true);
	void					stop();
	bool					enabled() const;
	void					sendall(const streaming_packet* packet);
	void					join();
	client_map*				clients();

public:
	lx::lepton*				lepton();
	lx::visual*				visual();

public:
	static void				accept_routine(server* self);
	static void				streaming_infrared_routine(server* self);
	static void				streaming_visual_routine(server* self);
};

} }

#endif