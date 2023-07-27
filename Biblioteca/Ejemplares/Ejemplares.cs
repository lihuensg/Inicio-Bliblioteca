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
    public partial class Ejemplares : UserControl
    {
        public Ejemplares()
        {
            InitializeComponent();
        }

        private void btnAltaEjemplar_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<DarDeAltaEjemplar>())
            {
                form.ShowDialog();
            }
        }

        private void btnEliminarEjemplar_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<EliminarEjemplares>())
            {
                form.ShowDialog();
            }
        }

        private void btnEditarEjemplar_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<EditarEjemplar>())
            {
                form.ShowDialog();
            }
        }

        private void btnBuscarEjemplar_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<BuscarEjemplar>())
            {
                form.ShowDialog();
            }
        }
    }
}