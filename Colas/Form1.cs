using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Colas
{
    public partial class Form1 : Form
    {
        Procesador procesador = new Procesador();
        public Form1()
        {
            InitializeComponent();
        }

        public void mostrar(int sinAtender, int atendidos, int pendientes, int ciclosPendientes)
        {
            txtInfo.Text = "Ciclos sin atender : " + sinAtender.ToString() + Environment.NewLine;
            txtInfo.Text += "Procesos atendidos : "+ atendidos.ToString() + Environment.NewLine;
            txtInfo.Text += "Procesos pendientes : " + pendientes.ToString() + Environment.NewLine;
            txtInfo.Text += "Ciclos pendientes: " + ciclosPendientes.ToString() + Environment.NewLine;
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            Proceso nuevo, aux;
            Random numero1 = new Random();
            Random numero2 = new Random();
            int sinAtender = 0, atendidos = 0, pendientes = 0, ciclosPendientes = 0, limite = 0, probabilidad, tiempo;

            for (int i = 0; i < 300; i++)
            {
                
                probabilidad = numero1.Next(100);
                
                if (probabilidad < 36)
                {
                    tiempo = numero2.Next(4, 14);

                    nuevo = new Proceso(tiempo);
                    procesador.Agregar(nuevo);

                    if (limite == 0 && procesador.Total() == 1)
                    {
                        aux = procesador.Eliminar();
                        limite = aux.Tiempo;
                    }
                }
                if (limite != 0)
                {
                    limite--;
                }
                else
                {
                    if (procesador.Total() > 0)
                    {
                        aux = procesador.Eliminar();
                        limite = aux.Tiempo;
                        atendidos++;
                    }
                    else
                    {
                        sinAtender++;
                    }
                }
            }

            if(procesador.Total() > 0)
            {
                pendientes = procesador.Total();

                while (procesador.Total() != 0)
                {
                    aux = procesador.Eliminar();
                    ciclosPendientes += aux.Tiempo;
                }
            }

            mostrar(sinAtender, atendidos, pendientes, ciclosPendientes);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
