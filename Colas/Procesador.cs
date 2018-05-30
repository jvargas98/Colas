using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas
{
    class Procesador
    {
        Proceso inicio = null;
        Proceso ultimo;
        Proceso aux;
        int total = 0;
        int sinAtender = 0, atendidos = 0, pendientes = 0, ciclosPendientes = 0;
  
        public Procesador()
        {
            aux = inicio;
        }
        public void Agregar(Proceso nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                aux = inicio;
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

        public void Eliminar()
        {
            Proceso aux = inicio;
            if(inicio == ultimo)
            {
                inicio = null;
                ultimo = null;
            }
            else
            {
                inicio = aux.Siguiente;
                inicio.Anterior = null;
            }
          
            total--;
   
        }

        public void Atender()
        {
           
            if (aux != null && aux.Tiempo != 0)
            {
                aux.Tiempo--;
            }
            else
            {
                if (Total() > 0)
                {
                    Eliminar();
                    aux = Mostrar();
                    atendidos++;
                }
                else
                {
                    sinAtender++;
                }
            }
        }

        public Proceso Mostrar()
        {
            return inicio;
        }

        public string Resultados()
        {
            string cadena = "";
            if (Total() > 0)
            {
                pendientes = Total();

                while (Total() != 0)
                {
                    aux = Mostrar();
                    ciclosPendientes += aux.Tiempo;
                    Eliminar();
                }
            }
            cadena = "sin atender : " + sinAtender + Environment.NewLine;
            cadena += "pendientes : " + pendientes + Environment.NewLine;
            cadena += "ciclos pendientes : " + ciclosPendientes;

            pendientes = 0; ciclosPendientes = 0; sinAtender = 0;

            return cadena;
        }
        public int Total()
        {
            return total;
        }

    }
}
