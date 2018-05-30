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

        private void btnSimular_Click(object sender, EventArgs e)
        {
            Proceso nuevo;
            Random numero1 = new Random();
            Random numero2 = new Random();
            int probabilidad, tiempo;

            for (int i = 0; i < 300; i++)
            {

                probabilidad = numero1.Next(100);
                
                if (probabilidad < 36)
                {
                    tiempo = numero2.Next(4, 14);

                    nuevo = new Proceso(tiempo);

                    procesador.Agregar(nuevo);
                    procesador.Atender();
                }
                else
                {
                    procesador.Atender();
                }

            }
            txtInfo.Text = procesador.Resultados();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
