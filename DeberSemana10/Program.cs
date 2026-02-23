using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaniaVacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conjunto universal (500 ciudadanos)
            HashSet<string> universo = GenerarCiudadanos(500);

            // Generar vacunados aleatoriamente
            HashSet<string> pfizer = SeleccionarVacunados(universo, 75);
            HashSet<string> astraZeneca = SeleccionarVacunados(universo, 75);

            // Unión P ∪ A
            HashSet<string> union = new HashSet<string>(pfizer);
            union.UnionWith(astraZeneca);

            // No vacunados U − (P ∪ A)
            HashSet<string> noVacunados = new HashSet<string>(universo);
            noVacunados.ExceptWith(union);

            // Ambas dosis P ∩ A
            HashSet<string> ambasDosis = new HashSet<string>(pfizer);
            ambasDosis.IntersectWith(astraZeneca);

            // Solo Pfizer P − A
            HashSet<string> soloPfizer = new HashSet<string>(pfizer);
            soloPfizer.ExceptWith(astraZeneca);

            // Solo AstraZeneca A − P
            HashSet<string> soloAstra = new HashSet<string>(astraZeneca);
            soloAstra.ExceptWith(pfizer);

            // Mostrar resultados
            MostrarResultados("No vacunados", noVacunados);
            MostrarResultados("Ambas dosis", ambasDosis);
            MostrarResultados("Solo Pfizer", soloPfizer);
            MostrarResultados("Solo AstraZeneca", soloAstra);

            Console.ReadLine();
        }

        static HashSet<string> GenerarCiudadanos(int cantidad)
        {
            HashSet<string> ciudadanos = new HashSet<string>();

            for (int i = 1; i <= cantidad; i++)
            {
                ciudadanos.Add($"Ciudadano {i}");
            }

            return ciudadanos;
        }

        static HashSet<string> SeleccionarVacunados(HashSet<string> universo, int cantidad)
        {
            if (cantidad > universo.Count)
            {
                throw new ArgumentException("La cantidad de vacunados no puede exceder el universo");
            }

            Random rnd = new Random();
            List<string> lista = universo.ToList();
            HashSet<string> vacunados = new HashSet<string>();

            // Fisher-Yates shuffle para mejor rendimiento
            for (int i = lista.Count - 1; i > lista.Count - cantidad - 1; i--)
            {
                int j = rnd.Next(i + 1);
                vacunados.Add(lista[j]);
                // Intercambiar
                string temp = lista[i];
                lista[i] = lista[j];
                lista[j] = temp;
            }

            return vacunados;
        }

        static void MostrarResultados(string titulo, HashSet<string> conjunto)
        {
            Console.WriteLine($"\n=== {titulo} ({conjunto.Count}) ===");

            if (conjunto.Count <= 20)
            {
                foreach (var ciudadano in conjunto)
                {
                    Console.WriteLine(ciudadano);
                }
            }
            else
            {
                Console.WriteLine("Primeros 10 registros:");
                foreach (var ciudadano in conjunto.Take(10))
                {
                    Console.WriteLine(ciudadano);
                }
                Console.WriteLine($"... y {conjunto.Count - 10} más");
            }
        }
    }
}
