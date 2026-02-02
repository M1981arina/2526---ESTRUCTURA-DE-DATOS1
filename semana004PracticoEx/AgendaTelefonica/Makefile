<<<<<<< HEAD
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
=======
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
>>>>>>> 9a6b31b0aee59bf8ab7fe49a8e1d800674cc99b6
