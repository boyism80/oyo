#ifndef __visual_h__
#define	__visual_h__

#ifdef _WIN32
#if defined DEBUG | defined _DEBUG
#pragma comment(lib, "opencv_world310d.lib")
#else
#pragma comment(lib, "opencv_world310.lib")
#endif
#endif

#include <opencv2/opencv.hpp>
#include <vector>

namespace lx {

class visual
{
private:
	cv::VideoCapture		_device;
	std::vector<uchar>		_buffer;

public:
	visual(int id = 0);
	~visual();

public:
	bool					transfer(void** buffer, size_t* width, size_t* height, size_t* size);
};

}

#endif