#ifndef AGENDA_H
#define AGENDA_H

#include <stddef.h>

#define NAME_MAX 100
#define PHONE_MAX 30
#define EMAIL_MAX 100

typedef struct {
    char name[NAME_MAX];
    char phone[PHONE_MAX];
    char email[EMAIL_MAX];
} Contact;

typedef struct {
    Contact *items;
    size_t count;
    size_t capacity;
} Agenda;

void initAgenda(Agenda *a);
void freeAgenda(Agenda *a);
int loadContacts(Agenda *a, const char *filename);
int saveContacts(Agenda *a, const char *filename);
void listContacts(Agenda *a);
void addContact(Agenda *a, Contact c);
int deleteContact(Agenda *a, size_t index);
int findContactByName(Agenda *a, const char *name);
void updateContact(Agenda *a, size_t index, Contact c);
void sortContactsByName(Agenda *a);

#endif // AGENDA_H
