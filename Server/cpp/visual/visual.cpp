#include "visual.h"

using namespace lx;

visual::visual(int id) : _device(id)
{}

visual::~visual()
{
	this->_device.release();
}

bool visual::transfer(void** buffer, size_t* width, size_t* height, size_t* size)
{
	if(this->_device.isOpened() == false)
	{
		puts("visual is not opened");
		return false;
	}

	cv::Mat				frame;
	if(this->_device.read(frame) == false)
	{
		puts("visual read is failed");
		return  false;
	}

	*width				= frame.cols;
	*height				= frame.rows;

	this->_buffer.clear();
	if(cv::imencode(".jpg", frame, this->_buffer) == false)
		return false;

	*buffer = (void*)this->_buffer.data();
	*size = this->_buffer.size();

	return true;
}