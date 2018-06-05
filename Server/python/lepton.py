import clepton

# class lepton:
# 	def __init__(self, name, spidev='/dev/spidev0.1'):
# 		self.__instance = clepton.create(spidev, name)
# 		if self.__instance is None:
# 			raise Exception('cannot create lepton instance')

# 	def __del__(self):
# 		pass

# 	def transfer(self):
# 		return clepton.transfer(self.__instance)




class lepton25():
	def __init__(self, spidev='/dev/spidev0.1'):
		self.__instance = clepton.create25(spidev)
		if self.__instance is None:
			raise Exception('cannot create lepton instance')

	def transfer(self):
		return clepton.transfer(self.__instance)

	def __del__(self):
		pass




class lepton30():
	def __init__(self, spidev='/dev/spidev0.1'):
		self.__instance = clepton.create30(spidev)
		if self.__instance is None:
			raise Exception('cannot create lepton instance')

	def transfer(self):
		return clepton.transfer(self.__instance)

	def __del__(self):
		pass