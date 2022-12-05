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
    public partial class BuscarEjemplar : Form
    {
        bool seleccionoEjemplar = false;
        public BuscarEjemplar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool SeleccionoEjemplar()
        {
            return seleccionoEjemplar;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            seleccionoEjemplar = true;
        }

        private void btnSelcObra_Click(object sender, EventArgs e)
        {
            BuscarOSeleccionarObra buscarOSeleccionarObra = new BuscarOSeleccionarObra();
            buscarOSeleccionarObra.ShowDialog();
        }
    }
}
