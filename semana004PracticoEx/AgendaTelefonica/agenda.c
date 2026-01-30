#include "agenda.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

static void ensureCapacity(Agenda *a, size_t minCapacity) {
    if (a->capacity >= minCapacity) return;
    size_t newCap = a->capacity ? a->capacity * 2 : 4;
    while (newCap < minCapacity) newCap *= 2;
    Contact *tmp = realloc(a->items, newCap * sizeof(Contact));
    if (!tmp) {
        fprintf(stderr, "Error: memoria insuficiente\n");
        exit(EXIT_FAILURE);
    }
    a->items = tmp;
    a->capacity = newCap;
}

void initAgenda(Agenda *a) {
    a->items = NULL;
    a->count = 0;
    a->capacity = 0;
}

void freeAgenda(Agenda *a) {
    free(a->items);
    a->items = NULL;
    a->count = a->capacity = 0;
}

static int icase_cmp(const char *a, const char *b) {
    while (*a && *b) {
        int ca = tolower((unsigned char)*a);
        int cb = tolower((unsigned char)*b);
        if (ca != cb) return ca - cb;
        a++; b++;
    }
    return tolower((unsigned char)*a) - tolower((unsigned char)*b);
}

void addContact(Agenda *a, Contact c) {
    ensureCapacity(a, a->count + 1);
    a->items[a->count++] = c;
}

// Since strdup+strlwr above are platform-dependent, implement a safe contains ignore-case
static int containsIgnoreCase(const char *hay, const char *needle) {
    if (!*needle) return 1;
    size_t hlen = strlen(hay), nlen = strlen(needle);
    for (size_t i = 0; i + nlen <= hlen; ++i) {
        size_t j;
        for (j = 0; j < nlen; ++j) {
            if (tolower((unsigned char)hay[i+j]) != tolower((unsigned char)needle[j])) break;
        }
        if (j == nlen) return 1;
    }
    return 0;
}

int findContactByName(Agenda *a, const char *name) {
    for (size_t i = 0; i < a->count; ++i) {
        if (containsIgnoreCase(a->items[i].name, name)) return (int)i;
    }
    return -1;
}

int deleteContact(Agenda *a, size_t index) {
    if (index >= a->count) return 0;
    for (size_t i = index; i + 1 < a->count; ++i) a->items[i] = a->items[i+1];
    a->count--;
    return 1;
}

void updateContact(Agenda *a, size_t index, Contact c) {
    if (index < a->count) a->items[index] = c;
}

void listContacts(Agenda *a) {
    if (a->count == 0) {
        puts("(Sin contactos)");
        return;
    }
    for (size_t i = 0; i < a->count; ++i) {
        printf("%zu: %s | %s | %s\n", i+1, a->items[i].name, a->items[i].phone, a->items[i].email);
    }
}

static int cmpName(const void *p1, const void *p2) {
    const Contact *a = p1, *b = p2;
    return icase_cmp(a->name, b->name);
}

void sortContactsByName(Agenda *a) {
    qsort(a->items, a->count, sizeof(Contact), cmpName);
}

int saveContacts(Agenda *a, const char *filename) {
    FILE *f = fopen(filename, "w");
    if (!f) return 0;
    for (size_t i = 0; i < a->count; ++i) {
        fprintf(f, "%s,%s,%s\n", a->items[i].name, a->items[i].phone, a->items[i].email);
    }
    fclose(f);
    return 1;
}

int loadContacts(Agenda *a, const char *filename) {
    FILE *f = fopen(filename, "r");
    if (!f) return 0;
    char line[512];
    while (fgets(line, sizeof(line), f)) {
        // remove trailing newline
        line[strcspn(line, "\r\n")] = 0;
        char *p1 = strtok(line, ",");
        char *p2 = strtok(NULL, ",");
        char *p3 = strtok(NULL, "");
        if (!p1) continue;
        Contact c = {"", "", ""};
        strncpy(c.name, p1, NAME_MAX-1);
        if (p2) strncpy(c.phone, p2, PHONE_MAX-1);
        if (p3) strncpy(c.email, p3, EMAIL_MAX-1);
        addContact(a, c);
    }
    fclose(f);
    return 1;
}
