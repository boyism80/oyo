#ifndef __lepton_h__
#define __lepton_h__

#ifdef _WIN32
#include <Windows.h>
#include <random>
#else
#include "vospi.h"
#endif
#include <exception>

#define SPIDEV_MESSAGE_LIMIT 	24


namespace lx {

class lepton
{
public:
	typedef enum _lepton_type { LEPTON_25, LEPTON_30, } type;

private:
	uint8_t 				_mode;
	uint8_t 				_bits;
	uint32_t 				_speed;
	uint16_t 				_delay;
	const char*				_spidev;

protected:
	int						_fd;
	vospi::frame			_frame;

protected:
	lepton(const char* spidev = "/dev/spidev0.1", int segment_count = 1);

public:
	virtual ~lepton();

private:
	bool					init();
	void					release();

public:
	virtual bool			transfer(uint16_t* buffer, size_t* size = NULL);
	virtual void			adjust(uint16_t* buffer, size_t size) = 0;
	
public:
	virtual int 			width() const = 0;
	virtual int 			height() const = 0;
};





class lepton25 : public lepton
{
public:
	lepton25(const char* spidev = "/dev/spidev0.1");
	virtual ~lepton25();

public:
	void					adjust(uint16_t* buffer, size_t size);
	int 					width() const;
	int 					height() const;
};




class lepton30 : public lepton
{
public:
	lepton30(const char* spidev = "/dev/spidev0.1");
	virtual ~lepton30();

public:
	void					adjust(uint16_t* buffer, size_t size);
	int 					width() const;
	int 					height() const;
};

}

#endif