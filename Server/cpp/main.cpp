#include "server.h"

void command_routine()
{
	char cmd[256];
	while(true)
	{
		scanf("%s", cmd);
#ifdef _WIN32
		if(_stricmp(cmd, "exit") == 0)
#else
		if(strcasecmp(cmd, "exit") == 0)
#endif
			break;
	}

	puts("Wait for exit...");
}

int main(int argc, const char** argv)
{
	// lx::lepton _lepton;
	// if(_lepton.init() == false)
	// {
	// 	puts("cannot open spi device");
	// 	return 0;
	// }

	// size_t size;
	// uint16_t buffer[19200] = {0,};
	// // while(true)
	// // {
	// 	if(_lepton.transfer(buffer, &size))
	// 		puts("complete");
	// 	else
	// 		puts("error");
	// // }

	// printf("size : %d\n", size);
	// for(int i = 0; i < size / sizeof(uint16_t); i++)
	// 	printf("%d ", buffer[i]);

	try
	{
		lx::im::server _server(8000, lx::lepton::type::LEPTON_30);
		if(_server.execute() == false)
			throw std::exception();

		command_routine();
	}
	catch(std::exception& e)
	{
		puts("exception");
	}

	return 0;
}