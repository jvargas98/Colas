using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Colas
{
    class Proceso
    {
        private int _tiempo;
        private Proceso siguiente;
        private Proceso anterior;


        public int Tiempo
        {
            get { return _tiempo; }
            set { _tiempo = value; }
        }

        public Proceso Siguiente
        {
            get{ return siguiente; }
            set{ siguiente = value; }
        }
        public Proceso Anterior
        {
            get{ return anterior; }
            set{ anterior = value; }
        }


        public Proceso(int tiempo)
        {
            _tiempo = tiempo;
        }

        public override string ToString()
        {
            string cadena = "";
            cadena = "Tiempo " + Tiempo;

            return cadena;
        }
    }
}
