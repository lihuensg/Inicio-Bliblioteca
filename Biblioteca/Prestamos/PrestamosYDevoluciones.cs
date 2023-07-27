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
using Microsoft.Extensions.DependencyInjection;

namespace Inicio_Bliblioteca
{
    public partial class PrestamosYDevoluciones : UserControl
    {
        public PrestamosYDevoluciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<RegistrarDevolucion>())
            {
                form.ShowDialog();
            }
        }

        private void btnRegistroPrestamos_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<RegistrarPrestamos>())
            {
                form.ShowDialog();
            }
        }

        private void btnBuscarPrestamos_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<BuscarPrestamo>())
            {
                form.ShowDialog();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
