using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas
{
    class Procesador
    {
        Proceso inicio;
        Proceso ultimo;
        int total = 0;

        public void Agregar(Proceso nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                ultimo = nuevo;
            }
            else
            {
                ultimo.Siguiente = nuevo;
                nuevo.Anterior = ultimo;
                ultimo = nuevo;
            }
            total++;
        }

        public Proceso Eliminar()
        {
            Proceso aux = ultimo;
            if(ultimo == inicio)
            {
                inicio = null;
                ultimo = null;
            }
            else
            {
                ultimo = ultimo.Anterior;
                ultimo.Siguiente = null;
            }
          
            total--;
            return aux;
        }

        public int Total()
        {
            return total;
        }

    }
}
