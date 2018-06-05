from lepton import *

if __name__ == '__main__':
	_lepton = lepton(spidev='/dev/spidev0.1', name='2.5')
	_buffer = _lepton.transfer()
	print(len(_buffer))

	# _lepton = lepton(spidev='/dev/spidev0.1', name='3.0')
	# _buffer = _lepton.transfer()
	# print(len(_buffer))


	_lepton = lepton25(spidev='/dev/spidev0.1')
	_buffer = _lepton.transfer()
	print(len(_buffer))

	# _lepton = lepton30(spidev='/dev/spidev0.1')
	# _buffer = _lepton.transfer()
	# print(len(_buffer))