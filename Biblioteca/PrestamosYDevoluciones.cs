using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplication;

namespace Inicio_Bliblioteca
{
    public partial class PrestamosYDevoluciones : UserControl
    {
        Fachada fachada;
        public PrestamosYDevoluciones()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarDevolucion registrarDevoucion = new RegistrarDevolucion();
            registrarDevoucion.ShowDialog();
          
        }

        private void btnRegistroPrestamos_Click(object sender, EventArgs e)
        {
            RegistrarPrestamos registrarPrestamo = new RegistrarPrestamos();
            registrarPrestamo.ShowDialog();
        }

        private void btnBuscarPrestamos_Click(object sender, EventArgs e)
        {
            BuscarPrestamo buscarPrestamo = new BuscarPrestamo();
            buscarPrestamo.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
