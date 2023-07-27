using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Inicio_Bliblioteca
{
    public partial class EditarEjemplar : Form
    {

        public EditarEjemplar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarEdicion_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<BuscarEdicion>())
            {
                form.ShowDialog();
            }
        }

        private void btnCrearEdicion_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<CrearEdicion>())
            {
                form.ShowDialog();
            }
        }
    }
}
