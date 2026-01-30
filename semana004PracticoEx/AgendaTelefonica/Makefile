CC=gcc
CFLAGS=-std=c11 -Wall -Wextra
TARGET=agenda
OBJS=main.o agenda.o

all: $(TARGET)

$(TARGET): $(OBJS)
	$(CC) $(CFLAGS) -o $(TARGET) $(OBJS)

main.o: main.c agenda.h
	$(CC) $(CFLAGS) -c main.c

agenda.o: agenda.c agenda.h
	$(CC) $(CFLAGS) -c agenda.c

clean:
	rm -f $(OBJS) $(TARGET)
