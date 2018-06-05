#include "vospi.h"
#include <errno.h>

using namespace vospi;

//
// vospi_packet_number
//	해당 패킷의 라인 넘버를 얻습니다.
//	이 값이 0이라면 첫 라인 라인을, 59라면 마지막 프레임의 라인을 얻습니다.
//
// Parameters
//	packet 			대상 패킷
//
// Return
//	해당 패킷의 라인 넘버
//
int vospi_packet_number(const vospi_packet* packet)
{
	return (packet->id & 0xff00) >> 8;
}


//
// vospi_packet_transfer
//	spi로부터 패킷을 읽어들입니다.
//	한 라인을 읽을 때 사용하므로 다수의 라인을 읽을 때 사용하면 성능이 좋지 않습니다.
//
// Parameters
//	packet 			대상 패킷
//	fd 				spi
//
// Return
// 	성공시 true, 실패시 false
//
bool vospi_packet_transfer(vospi_packet* packet, int fd)
{
	if(::read(fd, packet, sizeof(vospi_packet)) < 1)
		return false;

	return true;
}


//
// vospi_packet_valid
//	패킷이 유효한지 검사합니다.
//	제로 데이터가 포함되어 있는지를 검사하는 단순한 기능을 합니다.
//
// Parameters
//	packet 			대상 패킷
//
bool vospi_packet_valid(const vospi_packet* packet)
{
	for(int i = 0; i < LEPTON_WIDTH; i++)
	{
		if(packet->symbols[i] == 0)
			return false;
	}

	return true;
}









//
// vospi_segment_valid
//	유효한 세그먼트인지를 검사합니다.
//	패킷의 첫번째 바이트(id가 2바이트이므로 0xff00)는 반드시 0xff여야만 유효한 세그먼트입니다.
//
// Parameters
//	segment 				대상 세그먼트
//
// Return
//	성공시 true, 실패시 false
//
bool vospi_segment_valid(const vospi_segment* segment)
{
	return (segment->packets[0].id & 0x0f00) == 0x0f00;
}


//
// vospi_segment_synchronize
//	세그먼트의 동기화 여부를 확인합니다.
//	세그먼트의 20번째 라인의 첫번째 바이트는 반드시 0x14여야 합니다.
//
// Parameters
//	segment 				대상 세그먼트
//
// Return
//	성공시 true, 실패시 false
//
bool vospi_segment_synchronize(const vospi_segment* segment)
{
	// printf("sync : 0x%x\n", segment->packets[20].id);

	return (segment->packets[20].id & 0xff00) == 0x1400;
}


//
// vospi_segment_index
//	세그먼트의 번호를 확인합니다.
//	lepton 2.5는 한 세그먼트가 한 프레임이기 때문에 사용할 필요가 없지만
//	lepton 3.0의 경우 총 4 세그먼트가 하나의 프레임을 구성하기 때문에
//	이 값이 0~3의 값을 나타내야만 합니다.
//
// Parameters
//	segment 				대상 세그먼트
//
// Return
//	성공시 해당 세그먼트의 인덱스 (zero-based), 실패시 -1
//
int vospi_segment_index(const vospi_segment* segment)
{
	int ret = ((segment->packets[20].id & 0x00ff) & 0x70) >> 4;
	if(ret <= 0 || ret >= 5)
		return -1;

	return ret - 1;
}


//
// vospi_segment_transfer
//	spi로부터 데이터를 읽어옵니다.
//	offset 라인부터 count 만큼의 라인 수만큼 읽습니다.
//	offset이 1이고 count가 59라면 첫 번째 라인의 패킷을 제외한 나머지 패킷을 전부 읽어들입니다.
//
// Parameters
//	segment 				대상 세그먼트
//	fd 						spi
//	offset 					시작할 패킷 라인
//	count 					읽을 패킷 라인 수
//
// Return
//	성공시 true, 실패시 false
//
bool vospi_segment_transfer(vospi_segment* segment, int fd, int offset, int count)
{
	uint8_t* 				bytes 			= (uint8_t*)(segment->packets + offset);
	int 					full_size 		= sizeof(vospi_packet) * count;
	int 					bytes_offset 	= 0;
	
	while(bytes_offset < full_size)
	{
		int 				read_size 		= read(fd, (void*)(bytes + bytes_offset), full_size - bytes_offset);
		if(read_size == -1)
		{
			// printf("errno : %d\n", errno);
			return false;
		}

		bytes_offset += read_size;
	}

	return true;
}



//
// vospi_segment_contains_zero
//	세그먼트에 포함된 제로데이터를 확인합니다.
//
// Parameters
//	segment 				대상 세그먼트
//
// Return
//	성공시 true, 실패시 false
//

// bool contains_zero(const char* buffer, int size)
// {
// 	__asm	xor eax, eax
// 	__asm	mov edx, [ebp+0xC]				// edx : size
// 	__asm	
// 	__asm	$loop:
// 	__asm		cmp ecx, edx				// 인덱스를 검사합니다.
// 	__asm		jge $end
// 	__asm	
// 	__asm		mov ebx, [ebp+0x8]			// buffer[i]를 가져옵니다.
// 	__asm		add ebx, ecx
// 	__asm		movsx ebx, byte ptr [ebx]
// 	__asm
// 	__asm		cmp ebx, 0					// 0인지 검사합니다.
// 	__asm		je $success
// 	__asm
// 	__asm		add ecx, 1					// 인덱스를 1개 증가시킵니다.
// 	__asm		jmp $loop
// 	__asm	
// 	__asm	$success:
// 	__asm		inc eax						// 리턴값 1
// 	__asm	$end:
// }

bool vospi_segment_contains_zero(const vospi_segment* segment)
{
	for(int i = 0 ; i < LEPTON_HEIGHT; i++)
	{
		if(vospi_packet_valid(segment->packets + i) == false)
			return true;
	}

	return false;
}












//
// vospi_frame_init
//	프레임을 초기화합니다.
//
// Parameters
//	frame 					대상 프레임
//	count 					세그먼트 갯수
//
// Return
//	성공시 true, 실패시 false
//
bool vospi_frame_init(vospi_frame* frame, int count)
{
	frame->segments = (vospi_segment*)malloc(sizeof(vospi_segment) * count);
	frame->count = count;

	memset(frame->segments, 0, sizeof(vospi_segment) * count);
}

//
// vospi_frame_release
//	프레임 메모리를 해제합니다.
//
// Parameters
//	frame 					대상 프레임
//
// Return
//	없음
//
void vospi_frame_release(vospi_frame* frame)
{
	if(frame->segments != NULL)
	{
		free(frame->segments);
		frame->segments = NULL;
		frame->count = 0;
	}
}





//
// vospi::segment::segment
//	세그먼트의 생성자입니다.
//
// Parameters
//	없음
//
segment::segment()
{}

//
// vospi::segment::~segment
//	세그먼트의 소멸자입니다.
//
// Parameters
//	없음
//
segment::~segment()
{}


//
// vospi::segment::valid
//	해당 세그먼트가 유효한 세그먼트인지 검사합니다.
//
// Parameters
//	없음
//
// Return
//	성공시 true, 실패시 false
//
bool segment::valid() const
{
	return vospi_segment_valid(&this->_segment);
}

//
// vospi::segment::synchronize
//	해당 세그먼트의 동기화 여부를 검사합니다.
//
// Parameters
//	없음
//
// Return
//	성공시 true, 실패시 false
//
bool segment::synchronize() const
{
	return vospi_segment_synchronize(&this->_segment);
}

//
// vospi::segment::contains_zero
//	제로데이터가 포함된 세그먼트인지를 검사합니다.
//
// Parameters
//	없음
//
// Return
//	성공시 true, 실패시 false
//
bool segment::contains_zero() const
{
	return vospi_segment_contains_zero(&this->_segment);
}

//
// vospi::segment::index
//	세그먼트의 id를 얻어옵니다.
//
// Parameters
//	없음
//
// Return
//	성공시 세그먼트의 id, 실패시 -1
//
int segment::index() const
{
	return vospi_segment_index(&this->_segment);
}

//
// vospi::segment::transfer
//	spi로부터 데이터를 읽어옵니다.
//
// Parameters
//	fd 					spi
//	sync 				싱크가 맞지 않을 시 맞출지의 여부
//
// Return
//	성공시 true, 실패시 false
//
bool segment::transfer(int fd, bool sync)
{
	// puts("segment::transfer::before read first packet");
	int retry = 0;
	do
	{
		if(this->transfer(fd, 0, 1) == false)
			return false;

		if(retry++ > 30)
		{
			// printf("retry count : %d\n", retry);
			return false;
		}

	} while(this->valid());
	// puts("segment::transfer::after read first packet");



	// puts("segment::transfer::before read remaining packet");
	if(this->transfer(fd, 1, LEPTON_HEIGHT - 1) == false)
		return false;
	// puts("segment::transfer::after read remaining packet");



	// puts("segment::transfer::before check synchronized");
	if(this->synchronize() == false)
	{
		if(sync)
			usleep(185000);

		return false;
	}
	// puts("segment::transfer::after check synchronized");
	if(this->contains_zero())
		return false;
	// puts("segment::transfer::after check synchronized");

	return true;
}

//
// vospi::segment::transfer
//	spi로부터 데이터를 읽어옵니다.
//
// Parameters
//	fd 					spi
//	offset 				시작 패킷 넘버
// 	count 				읽을 패킷의 갯수
//
// Return
//	성공시 true, 실패시 false
//
bool segment::transfer(int fd, int offset, int count)
{
	return vospi_segment_transfer(&this->_segment, fd, offset, count);
}

//
// vospi::segment::frame_number
//	세그먼트에 포함된 패킷의 라인 넘버를 얻습니다.
//
// Parameters
//	packet_index 		대상 패킷
//
// Return
//	패킷의 라인 넘버를 반환
//
int segment::frame_number(int packet_index)
{
	return vospi_packet_number(this->_segment.packets + packet_index);
}

//
// vospi::segment::element
//	세그먼트가 가진 데이터의 아이템 하나를 얻습니다.
//
// Parameters
//	row 				가로 열
//	col					세로 행
//
// Return
//	세그먼트의 데이터를 반환
//
uint16_t segment::element(int row, int col)
{
	return this->_segment.packets[row].symbols[col];
}

//
// size
//	세그먼트의 총 크기를 얻습니다.
//	이 값은 고정이며 9600입니다. (80*60*sizeof(uint16_t))
//
// Parameters
//	없음
//
// Return
//	세그먼트 데이터의 총 크기 (9600)
//
int segment::size()
{
	return 9600; // 80*60*sizeof(uint16_t)
}




//
// vospi::frame::frame
//	프레임의 생성자입니다.
//
// Parameters
//	segment_count 		세그먼트 갯수
//
frame::frame(int segment_count) : _segments(NULL), _count(0)
{
	this->init(segment_count);
}

//
// vospi::frame::~frame
//	프레임의 소멸자입니다.
//
// Parameters
//	없음
//
frame::~frame()
{
	this->release();
}

//
// vospi::frame::init
//	프레임을 초기화합니다.
//
// Parameters
//	segment_count 		세그먼트 갯수
//
// Return
//	성공시 true, 실패시 false
//
bool frame::init(int count)
{
	if(this->_segments == NULL)
	{
		this->_segments		= new segment[count];
		this->_count		= count;
	}
}

//
// vospi::frame:release
//	프레임 메모리를 해제합니다.
//
// Parameters
//	없음
//
// Return
//	없음
//
void frame::release()
{
	// puts("frame::release::before free memory");
	if(this->_segments != NULL)
		delete[] this->_segments;
	this->_count = 0;
	// puts("frame::release::after free memory");
}

//
// vospi::frame::count
//	프레임이 가진 세그먼트의 갯수를 반환합니다.
//
// Parameters
//	없음
//
// Return
//	세그먼트의 카운트
//
int frame::count() const
{
	return this->_count;
}

//
// vospi::frame::get
//	프레임이 가진 세그먼트를 반환합니다.
//
// Parameters
//	index 				세그먼트 오프셋
//
// Return
//	성공시 해당 세그먼트를 리턴, 실패시 null
//
segment* frame::get(int index)
{
	if(index >= this->_count || index < 0)
		return NULL;

	return this->_segments + index;
}

//
// vospi::frame::get
//	프레임이 가진 세그먼트를 반환합니다.
//
// Parameters
//	index 				세그먼트 오프셋
//
// Return
//	성공시 해당 세그먼트를 리턴, 실패시 null
//
const segment* frame::get(int index) const
{
	if(index >= this->_count || index < 0)
		return NULL;
	
	return this->_segments + index;
}

//
// vospi::frame::transfer
//	spi로부터 한 프레임을 읽어 버퍼에 저장합니다.
//
// Parameters
//	index 				세그먼트 오프셋
//
// Return
//	성공시 해당 세그먼트를 리턴, 실패시 null
//
bool frame::transfer(int fd, uint16_t* buffer, size_t* size)
{
	uint8_t				status_bits = 0;
	int					current_id = 0;
	int					retry = 0;
	bool				use_sync = false;

	while(current_id < this->count())
	{
		segment*		current_segment = this->get(current_id);
		if(current_segment->transfer(fd, use_sync) == false)
		{
			// puts("failed to read segment data");
			if(++retry > 30)
				use_sync = true;

			continue;
		}
		// puts("success to read segment data");
		
		use_sync = false;
		retry = 0;

		// puts("before check segment id");
		if(this->count() > 1 && current_segment->index() != current_id)
		{
			// puts("invalid segment id");
			current_id = 0;
			continue;
		}
		// puts("after check segment id");

		// puts("frame::transfer::before store dataset");
		for(int row = 0; row < LEPTON_HEIGHT; row++)
		{
			for(int col = 0; col < LEPTON_WIDTH; col++)
			{
				int offset 			= current_id * (LEPTON_WIDTH * LEPTON_HEIGHT) + (row * LEPTON_WIDTH + col);
				buffer[offset] 		= FLIP_WORD_BYTES(current_segment->element(row, col));
			}
		}
		// puts("frame::transfer::after store dataset");

		current_id++;
	}

	if(size != NULL)
		*size 						= this->size();

	return true;
}

//
// vospi::frame::size
//	프레임이 가지는 총 크기를 나타냅니다.
//
// Parameters
//	없음
//
// Return
//	한 프레임의 총 데이터 크기
//	lepton 2.5의 경우 9600
//	lepton 3.5의 경우 38400
//
int frame::size() const
{
	return this->count() * segment::size();
}

//
// vospi::frame::operator []
//	get 함수와 동일합니다.
//
// Parameters
//	index 				세그먼트 오프셋
//
// Return
//	성공시 해당 세그먼트를 리턴, 실패시 null
//
segment* frame::operator [] (int index)
{
	return this->get(index);
}