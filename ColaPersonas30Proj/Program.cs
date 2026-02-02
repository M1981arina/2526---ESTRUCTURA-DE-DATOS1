using System;
using System.Collections.Generic;

namespace ColaPersonas
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MaxAsientos = 30;
            int asientos = MaxAsientos;
            bool noWait = Array.IndexOf(args, "--no-wait") >= 0;

            // Permitir pasar número de asientos como primer argumento: `dotnet run -- 5 --no-wait`
            if (args.Length > 0 && int.TryParse(args[0], out int parsedArg))
            {
                if (parsedArg < 1)
                {
                    Console.WriteLine("Argumento inválido para asientos. Usando valor por defecto 30.");
                    asientos = MaxAsientos;
                }
                else if (parsedArg > MaxAsientos)
                {
                    Console.WriteLine($"El número máximo es {MaxAsientos}. Usando {MaxAsientos}.");
                    asientos = MaxAsientos;
                }
                else
                {
                    asientos = parsedArg;
                    Console.WriteLine($"Usando argumento: asientos = {asientos}");
                }
            }
            else
            {
                Console.Write($"Ingrese número de asientos (1-{MaxAsientos}) [Enter = {MaxAsientos}]: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    asientos = MaxAsientos;
                }
                else if (!int.TryParse(input, out asientos) || asientos < 1)
                {
                    Console.WriteLine("Entrada inválida. Se usará el valor por defecto: 30.");
                    asientos = MaxAsientos;
                }
                else if (asientos > MaxAsientos)
                {
                    Console.WriteLine($"El número máximo es {MaxAsientos}. Usando {MaxAsientos}.");
                    asientos = MaxAsientos;
                }
            }

            var cola = new Queue<string>();

            for (int i = 1; i <= asientos; i++)
            {
                cola.Enqueue($"Persona {i}");
                Console.WriteLine($"Persona {i} ingresó a la cola");
            }

            Console.WriteLine("\nAsignación de asientos:\n");

            int numeroAsiento = 1;
            while (cola.Count > 0)
            {
                var persona = cola.Dequeue();
                Console.WriteLine($"Asiento {numeroAsiento} asignado a {persona}");
                numeroAsiento++;
            }

            Console.WriteLine($"\nSe asignaron {asientos} asientos.");
            if (!noWait)
            {
                Console.WriteLine("Presione cualquier tecla para salir...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("(no-wait) Ejecución finalizada.");
            }
        }
    }
}
