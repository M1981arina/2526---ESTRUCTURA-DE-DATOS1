# Agenda Telefónica (C)

Proyecto simple en C que implementa una agenda telefónica con operaciones básicas:
- Agregar, listar, buscar, modificar, eliminar, ordenar
- Guardar y cargar desde archivo CSV (`contacts.csv`)

Compilación (GNU GCC):

```bash
gcc -std=c11 -Wall -Wextra -o agenda main.c agenda.c
```

En Windows use MinGW/MSYS o WSL. También puede usar el `Makefile` si dispone de `make`.

Uso:
- Ejecute `./agenda` y siga el menú.
- Los contactos se guardan automáticamente al salir en `contacts.csv`.
