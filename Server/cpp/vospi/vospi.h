#ifndef	__vospi_h__
#define	__vospi_h__

#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <fcntl.h>
#include <limits.h>
#include <memory.h>
#include <unistd.h>
#include <getopt.h>
#include <sys/ioctl.h>
#include <linux/types.h>
#include <linux/spi/spidev.h>

#define VOSPI_FRAME_SIZE 		164
#define LEPTON_WIDTH			80
#define LEPTON_HEIGHT			60

#define FLIP_WORD_BYTES(word) (word >> 8) | (word << 8)

//
// C 스타일의 vospi 타입
//


//
// vospi_packet
//	FLIR에서 정의한 프로토콜 형식입니다.
//	프레임의 한 라인 (80픽셀)에 대한 정보를 담고 있습니다.
//
typedef struct _vospi_packet_t
{
	uint16_t				id; 						// 패킷의 id
	uint16_t				crc; 						// 패킷의 crc
	uint16_t				symbols[LEPTON_WIDTH]; 		// 패킷의 데이터
} vospi_packet;


int 						vospi_packet_number(const vospi_packet* packet);
bool 						vospi_packet_transfer(vospi_packet* packet, int fd);
bool						vospi_packet_valid(const vospi_packet* packet);

//
// vospi_segment
//	하나의 세그먼트에 대한 정보를 나타냅니다.
//	lepton 2.5의 경우 한 세그먼트가 한 프레임을 나타냅니다.
//	lepton 3.0의 경우 네 개의 세그먼트가 한 프레임을 구성합니다.
//
typedef struct _vospi_segment_t
{
	vospi_packet 			packets[LEPTON_HEIGHT]; 	// 세그먼트의 패킷 데이터
} vospi_segment;

bool 						vospi_segment_valid(const vospi_segment* segment);
bool 						vospi_segment_synchronize(const vospi_segment* segment);
int  						vospi_segment_index(const vospi_segment* segment);
bool 						vospi_segment_transfer(vospi_segment* segment, int fd, int offset, int count);
bool						vospi_segment_contains_zero(const vospi_segment* segment);


//
// vospi_frame
//	한 프레임을 구성합니다.
//	lepton 2.5는 count가 1이 될 것이고, lepton 3.0은 count가 4가 될 것입니다.
//
typedef struct _vospi_frame_t
{
	vospi_segment* 			segments;				// 프레임의 세그먼트 데이터
	int 					count;					// 세그먼트 갯수
} vospi_frame;


bool 						vospi_frame_init(vospi_frame* frame, int count);
void 						vospi_frame_release(vospi_frame* frame);



//
// C++ 스타일의 vospi 타입
//

namespace vospi {

//
// vospi::segment
//	vospi_segment의 랩핑 클래스입니다.
//
class segment
{
private:
	vospi_segment			_segment;				// C 형식의 세그먼트

public:
	
	segment();

	
	~segment();

public:
	
	bool					valid() const;
	bool					synchronize() const;
	bool					contains_zero() const;
	int						index() const;
	bool					transfer(int fd, bool sync = true);
	bool					transfer(int fd, int offset, int count);

public:
	int 					frame_number(int packet_index);
	uint16_t				element(int row, int col);

public:
	
	static int				size();
};


//
// vospi::frame
//	한 프레임을 나타내는 클래스입니다.
//	vospi_frame을 랩핑한 클래스가 아닙니다.
//
class frame
{
private:
	segment*				_segments;			// 세그먼트 데이터
	int						_count;				// 세그먼트 갯수

public:
	
	frame(int segment_count);

	
	~frame();

private:
	
	bool					init(int segment_count);
	void					release();

public:
	int 					count() const;
	segment*				get(int index);
	const segment*			get(int index) const;
	bool					transfer(int fd, uint16_t* buffer, size_t* size);
	int						size() const;

public:
	segment*				operator [] (int index);
};

}

#endif