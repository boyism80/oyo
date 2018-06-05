#include "server.h"
using namespace lx::im;

streaming_packet::streaming_packet()
{
	this->_bytes			= NULL;
	this->_size				= 0;
	this->_capacity			= 0;
}

streaming_packet::~streaming_packet()
{
	if(this->_bytes != NULL)
		free(this->_bytes);
}

bool streaming_packet::set(const void* bytes, size_t size)
{
	if(this->realloc(size) == false)
		return false;

	memcpy(this->_bytes, bytes, size);

	return true;
}

bool streaming_packet::realloc(size_t size)
{
	if(this->_capacity < size)
	{
		this->_bytes		= ::realloc(this->_bytes, size);
		this->_capacity		= size;
	}

	this->_size				= size;
	return this->_bytes != NULL;
}

void* streaming_packet::bytes()
{
	return this->_bytes;
}

const void* streaming_packet::bytes() const
{
	return this->_bytes;
}

size_t streaming_packet::size() const
{
	return this->_size;
}

bool streaming_packet::encode(int frame_type, const void* bytes, int width, int height, int size, streaming_packet* packet)
{
	int 				ensize 		= (sizeof(uint32_t) * 4) + size;
	if(packet->realloc(ensize) == false)
		return false;

	uint8_t*			buffer 		= (uint8_t*)packet->bytes();
	int 				offset 		= 0;

	memcpy(buffer + offset, &frame_type, sizeof(int));
	offset += sizeof(int);

	memcpy(buffer + offset, &width, sizeof(int));
	offset += sizeof(int);

	memcpy(buffer + offset, &height, sizeof(int));
	offset += sizeof(int);

	memcpy(buffer + offset, &size, sizeof(int));
	offset += sizeof(int);

	memcpy(buffer + offset, bytes, size);
	return true;
}






client::client(int fd)
{
	this->_socket = fd;
}

client::~client()
{}

bool client::recv(void** buffer, int size)
{
	this->_buffer.clear();
	this->_buffer.reserve(size);

	int					offset = 0;
	while(offset != size)
	{
#ifdef _WIN32
		int recvsize = ::recv(this->_socket, (char*)(this->_buffer.data() + offset), size - offset, 0);
#else
		int recvsize = ::recv(this->_socket, (void*)(this->_buffer.data() + offset), size - offset, 0);
#endif
		if(recvsize <= 0)
			return false;

		offset += recvsize;
	}

	*buffer = (void*)this->_buffer.data();
	return true;
}

bool client::send(const void* bytes, int size)
{
	int ret;
this->_mutex.lock();
	try
	{
#ifdef _WIN32
		ret = ::send(this->_socket, (const char*)bytes, size, 0);
#else
		ret = ::send(this->_socket, (void*)bytes, size, MSG_NOSIGNAL);
#endif
	}
	catch(...)
	{
		ret = false;
	}
this->_mutex.unlock();

	return ret != -1;
}

bool client::recv(void** buffer, int* size)
{
	void*					buffer_ref;
	if(this->recv(&buffer_ref, sizeof(int)) == false)
		return false;

	int					buffer_size = 0;
	memcpy((void*)&buffer_size, buffer_ref, sizeof(int));

	if(this->recv(&buffer_ref, buffer_size) == false)
		return false;

	*buffer 				= buffer_ref;
	*size 					= buffer_size;
	return true;
}

void client::close()
{
#ifdef _WIN32
	::closesocket(this->_socket);
#else
	::close(this->_socket);
#endif
}

bool client::equals(int fd) const
{
	return (this->_socket == fd);
}

bool client::connected() const
{
	int error;
	socklen_t len;
	::getsockopt(this->_socket, SOL_SOCKET, SO_ERROR, &error, &len);

	return error == 0;
}

bool client::operator == (int fd) const
{
	return this->equals(fd);
}

bool client::operator != (int fd) const
{
	return !(this->equals(fd));
}

client::operator int() const
{
	return this->_socket;
}





client_map::client_map()
{
	this->_socket			= 0;
	this->_max_fd			= 0;
}

client_map::~client_map()
{}

void client_map::init(int fd)
{
	this->_socket			= fd;
	this->_max_fd			= fd;
	FD_ZERO(&this->_fdset);
	FD_SET(this->_socket, &this->_fdset);
}

bool client_map::select(client*** events, int* count)
{
	struct timeval			time;
	time.tv_sec 			= 5;
	time.tv_usec 			= 0;

	fd_set 					evented_fd 		= this->_fdset;
	int 					fd_num  		= ::select(this->_max_fd + 1, &evented_fd, (fd_set*)0, (fd_set*)0, &time);
	if(fd_num == -1)
		return false;

	if(fd_num == 0)
	{
		*events 			= NULL;
		*count 				= 0;
		return true;
	}

	this->_events.clear();
	this->_events.reserve(fd_num);

	for(int event_socket = 0; event_socket < this->_max_fd + 1; event_socket++)
	{
		if(FD_ISSET(event_socket, &evented_fd) == false)
			continue;

		std::map<int, client*>::iterator i = this->find(event_socket);
		if(event_socket != this->_socket && i == this->end())
			continue;

		this->_events.push_back(event_socket == this->_socket ? NULL : i->second);
	}

	*events 			= this->_events.data();
	*count 				= this->_events.size();
	return true;
}

bool client_map::accept()
{
	struct sockaddr_in	caddr 		= {0,};
	int 				caddr_size 	= sizeof(caddr);
#ifdef _WIN32
	int 				client_fd	= ::accept(this->_socket, (struct sockaddr*)&caddr, &caddr_size);
#else
	int 				client_fd	= ::accept(this->_socket, (struct sockaddr*)&caddr, (socklen_t*)&caddr_size);
#endif

	client*				created		= new client(client_fd);
this->_client_mutex.lock();
	this->insert(std::pair<int, client*>(client_fd, created));

	FD_SET(client_fd, &this->_fdset);
	this->_max_fd					= max(this->_max_fd, client_fd);
this->_client_mutex.unlock();
	
	return true;
}

bool client_map::remove(client* c)
{
	bool				ret 		= true;
this->_client_mutex.lock();
	try
	{
		std::map<int, client*>::iterator i = this->find(*c);
		if(i == this->end())
			throw std::exception();

		FD_CLR(i->first, &this->_fdset);

		this->erase(i);

		c->close();
		
		delete c;
	}
	catch(std::exception& e)
	{
		ret 						= false;
	}
this->_client_mutex.unlock();

	return ret;
}

bool client_map::sendall(const streaming_packet* packet)
{
this->_client_mutex.lock();
	for(std::map<int, client*>::const_iterator i = this->cbegin(); i != this->cend(); i++)
	{
		i->second->send(packet->bytes(), packet->size());
	}
this->_client_mutex.unlock();

	return true;
}




server::server(int port, lx::lepton::type type, const char* spidev, int camera_device) : _streaming(false),
																						 _lepton(NULL), _visual(camera_device), 
																						 _accept_thread(NULL), _istreaming_thread(NULL), _vstreaming_thread(NULL)
{
	if(this->init(port) == false)
		throw std::exception();

#ifdef _WIN32

#else
	if(type == lx::lepton::type::LEPTON_25)
		this->_lepton = new lx::lepton25(spidev);
	else if(type == lx::lepton::type::LEPTON_30)
		this->_lepton = new lx::lepton30(spidev);
	else
		throw std::exception();
#endif
}

server::~server()
{
	this->stop();

#ifdef _WIN32
	WSACleanup();
#else
	if(this->_lepton != NULL)
		delete this->_lepton;
#endif
}

bool server::init(int port)
{
	try
	{
#ifdef _WIN32
		WSAData wsa;
		if(WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
			throw std::exception();
#endif

		if((this->_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP)) == -1)
			throw std::exception();

		int config_value = 1;
#ifdef _WIN32
		if(setsockopt(this->_socket, SOL_SOCKET, SO_REUSEADDR, (const char*)&config_value, sizeof(config_value)) == -1)
#else
		if(setsockopt(this->_socket, SOL_SOCKET, SO_REUSEADDR, &config_value, sizeof(config_value)) == -1)
#endif
			throw std::exception();

		struct sockaddr_in addr			= {0,};
		addr.sin_family					= AF_INET;
		addr.sin_addr.s_addr			= htonl(INADDR_ANY);
		addr.sin_port					= htons(8000);
		if(bind(this->_socket, (struct sockaddr*)&addr, sizeof(addr)) == -1)
			throw std::exception();


		if(listen(this->_socket, SOMAXCONN) == -1)
			throw std::exception();

		this->_clients.init(this->_socket);

		return true;
	}
	catch(std::exception& e)
	{
		this->release();

		return false;
	}
}

void server::release()
{
	if(this->_socket != -1)
#ifdef _WIN32
		closesocket(this->_socket);
#else
		close(this->_socket);
#endif
}

bool server::execute(bool async)
{
	if(this->_streaming)
		return false;

	this->_streaming			= true;
	this->_accept_thread		= new std::thread(server::accept_routine, this);
	this->_istreaming_thread	= new std::thread(server::streaming_infrared_routine, this);
	this->_vstreaming_thread	= new std::thread(server::streaming_visual_routine, this);

	if(!async)
		this->join();

	return true;
}

void server::stop()
{
	this->_streaming 			= false;
	this->join();
}

bool server::enabled() const
{
	return this->_streaming;
}

void server::sendall(const streaming_packet* packet)
{
	this->_clients.sendall(packet);
}

void server::join()
{
	if(this->_accept_thread != NULL)
	{
		this->_accept_thread->join();
		delete this->_accept_thread;
		this->_accept_thread = NULL;
	}

	if(this->_istreaming_thread != NULL)
	{
		this->_istreaming_thread->join();
		delete this->_istreaming_thread;
		this->_istreaming_thread = NULL;
	}

	if(this->_vstreaming_thread != NULL)
	{
		this->_vstreaming_thread->join();
		delete this->_vstreaming_thread;
		this->_vstreaming_thread = NULL;
	}
}

client_map* server::clients()
{
	return &this->_clients;
}

lx::lepton* server::lepton()
{
	return this->_lepton;
}

lx::visual* server::visual()
{
	return &(this->_visual);
}

void server::accept_routine(server* self)
{
	client_map*					clients = self->clients();
	client**					events;
	int							count;

	void*						buffer;
	int							bufsize;

	while(self->enabled())
	{
		if(clients->select(&events, &count) == false)
			continue;

		if(count == 0)
			continue;

		for(int i = 0; i < count; i++)
		{
			if(events[i] == NULL)
			{
				clients->accept();
			}
			else if(events[i]->recv(&buffer, &bufsize) == false)
			{
				clients->remove(events[i]);
			}
			else
			{
				// Receive data from client
			}
		}
	}
}

void server::streaming_infrared_routine(server* self)
{
	uint16_t					buffer[19200];
	streaming_packet			packet;
	int 						width = self->lepton()->width();
	int 						height = self->lepton()->height();
	size_t						size;

	while(self->enabled())
	{
		if(self->lepton()->transfer(buffer, &size) == false)
			continue;

		if(streaming_packet::encode(0, (const void*)buffer, width, height, size, &packet) == false)
			continue;

		self->sendall(&packet);
	}
}

void server::streaming_visual_routine(server* self)
{
	void*						buffer;
	size_t						width, height, size;
	streaming_packet			packet;


	while(self->enabled())
	{
		if(self->visual()->transfer(&buffer, &width, &height, &size) == false)
			continue;

		if(streaming_packet::encode(1, (const void*)buffer, width, height, size, &packet) == false)
			continue;

		self->sendall(&packet);
	}
}