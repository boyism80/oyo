#include "lepton.h"
#include <errno.h>

using namespace lx;

lepton::lepton(const char* spidev, int segment_count) : _frame(segment_count)
{
#ifdef _WIN32
#else
	this->_fd								= 0;
	this->_mode								= SPI_CPOL | SPI_CPHA;
	this->_bits								= 8;
	this->_speed							= 18000000;
	this->_delay							= 0;
	this->_spidev							= spidev;

	if(this->init() == false)
		throw std::exception();

#endif
}

lepton::~lepton()
{
	this->release();
}

bool lepton::init()
{
	try
	{
#ifdef _WIN32
		
#else
		this->_fd = open(this->_spidev, O_RDWR);
		if(this->_fd < 0)
			throw "can't open device";

		if(ioctl(this->_fd, SPI_IOC_WR_MODE, &this->_mode) == -1)
			throw "can't set spi mode";

		if(ioctl(this->_fd, SPI_IOC_RD_MODE, &this->_mode) == -1)
			throw "can't get spi mode";

		if(ioctl(this->_fd, SPI_IOC_WR_BITS_PER_WORD, &this->_bits) == -1)
			throw "can't set bits per word";

		if(ioctl(this->_fd, SPI_IOC_RD_BITS_PER_WORD, &this->_bits) == -1)
			throw "can't get bits per word";

		if(ioctl(this->_fd, SPI_IOC_WR_MAX_SPEED_HZ, &this->_speed) == -1)
			throw "can't set max speed hz";

		if(ioctl(this->_fd, SPI_IOC_RD_MAX_SPEED_HZ, &this->_speed) == -1)
			throw "can't get max speed hz";
#endif

		return true;
	}
	catch(const char* e)
	{
		return false;
	}
}

void lepton::release()
{
	if(this->_fd)
	{
#ifdef _WIN32

#else
		close(this->_fd);
#endif
		this->_fd			= 0;
	}
}

bool lepton::transfer(uint16_t* buffer, size_t* size)
{
#ifdef _WIN32
	
	std::random_device rn;
	std::mt19937_64 rnd(rn());
	std::uniform_int_distribution<int> range(28000, 33000);

	for(int row = 0; row < LEPTON_HEIGHT; row++)
	{
		for(int col = 0; col < LEPTON_WIDTH; col++)
			buffer[row * LEPTON_WIDTH + col] = range(rnd);
	}

	Sleep(1000 / 30);
	return true;

#else
	bool ret = this->_frame.transfer(this->_fd, buffer, size);
	this->adjust(buffer, *size);

	return ret;

#endif
}




lepton25::lepton25(const char* spidev) : lepton(spidev, 1)
{}

lepton25::~lepton25()
{}

void lepton25::adjust(uint16_t* buffer, size_t size)
{
	int count = size / sizeof(uint16_t);
	for(int i = 0; i < count; i++)
		buffer[i] = buffer[i] - 27280;
}

int lepton25::width() const
{
	return 80;
}

int lepton25::height() const
{
	return 60;
}



lepton30::lepton30(const char* spidev) : lepton(spidev, 4)
{}

lepton30::~lepton30()
{}

void lepton30::adjust(uint16_t* buffer, size_t size)
{
	int count = size / sizeof(uint16_t);
	for(int i = 0; i < count; i++)
		buffer[i] = (buffer[i] - 7452) * (92.60f / 34.78f);
}

int lepton30::width() const
{
	return 160;
}

int lepton30::height() const
{
	return 120;
}