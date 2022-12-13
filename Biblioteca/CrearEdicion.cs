using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio_Bliblioteca
{
    public partial class CrearEdicion : Form
    {
        public CrearEdicion()
        {
            InitializeComponent();
        }

        private void btnBuscarEdicion_Click(object sender, EventArgs e)
        {
            BuscarEdicion buscarEdicion = new BuscarEdicion();
            buscarEdicion.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
