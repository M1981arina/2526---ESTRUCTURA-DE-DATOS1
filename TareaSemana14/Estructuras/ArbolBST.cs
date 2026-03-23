using ProyectoBST.Modelos;

namespace ProyectoBST.Estructuras
{
    public class ArbolBST
    {
        private Nodo raiz;

        public ArbolBST()
        {
            raiz = null;
        }

        public void Insertar(int valor)
        {
            raiz = InsertarRecursivo(raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return new Nodo(valor);
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
            }

            return nodo;
        }

        public bool Buscar(int valor)
        {
            return BuscarRecursivo(raiz, valor);
        }

        private bool BuscarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                return false;
            }

            if (valor == nodo.Valor)
            {
                return true;
            }
            else if (valor < nodo.Valor)
            {
                return BuscarRecursivo(nodo.Izquierdo, valor);
            }
            else
            {
                return BuscarRecursivo(nodo.Derecho, valor);
            }
        }

        public void InOrden()
        {
            Console.Write("Inorden: ");
            InOrdenRecursivo(raiz);
            Console.WriteLine();
        }

        private void InOrdenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                InOrdenRecursivo(nodo.Izquierdo);
                Console.Write(nodo.Valor + " ");
                InOrdenRecursivo(nodo.Derecho);
            }
        }
    }
}
