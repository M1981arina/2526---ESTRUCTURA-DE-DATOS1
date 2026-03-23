using ProyectoBST.Estructuras;

namespace ProyectoBST.Utilidades
{
    public class Menu
    {
        private ArbolBST arbol = new ArbolBST();

        public void Mostrar()
        {
            int opcion;

            do
            {
                Console.WriteLine("\n--- MENU BST ---");
                Console.WriteLine("1. Insertar");
                Console.WriteLine("2. Buscar");
                Console.WriteLine("3. Mostrar Inorden");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Valor: ");
                        int v = int.Parse(Console.ReadLine());
                        arbol.Insertar(v);
                        Console.WriteLine("Valor insertado correctamente");
                        break;

                    case 2:
                        Console.Write("Buscar: ");
                        int b = int.Parse(Console.ReadLine());
                        Console.WriteLine(arbol.Buscar(b) ? "Existe" : "No existe");
                        break;

                    case 3:
                        arbol.InOrden();
                        break;

                    case 0:
                        Console.WriteLine("¡Gracias por usar el programa!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

            } while (opcion != 0);
        }
    }
}
