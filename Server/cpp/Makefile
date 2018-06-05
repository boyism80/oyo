CC = g++
INC = ./vospi ./lepton ./visual ./server
INC_PARAMS=$(foreach d, $(INC), -I$d)
LIB = `pkg-config opencv --cflags --libs` -lpthread
CFLAGS = -W -Iinclude $(INC_PARAMS) $(LIB)
TARGET = main

# Without based macro ------------------------------------------

$(TARGET) : vospi.o lepton.o visual.o server.o main.o
	$(CC) $(CFLAGS) -o $(TARGET) vospi.o lepton.o visual.o server.o main.o
	# make clean

vospi.o : ./vospi/vospi.cpp
	$(CC) $(CFLAGS) -c -o vospi.o ./vospi/vospi.cpp

lepton.o : ./lepton/lepton.cpp
	$(CC) $(CFLAGS) -c -o lepton.o ./lepton/lepton.cpp

visual.o : ./visual/visual.cpp
	$(CC) $(CFLAGS) -c -o visual.o ./visual/visual.cpp

server.o : ./server/server.cpp
	$(CC) $(CFLAGS) -c -o server.o ./server/server.cpp

main.o : main.cpp
	$(CC) $(CFLAGS) -c -o main.o main.cpp

# With based macro --------------------------------------------

# OBJECTS = lepton.o visual.o server.o main.o
# all : $(TARGET)

# $(TARGET) : $(OBJECTS)
# 	$(CC) $(CFLAGS) -o $@ $^			# $@ : 현재 타겟의 이름
# 										# $^ : 현재 타겟의 종속 항목 리스트

clean:
	rm *.o