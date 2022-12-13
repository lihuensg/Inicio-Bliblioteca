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
    public partial class Ejemplares : UserControl
    {
        public Ejemplares()
        {
            InitializeComponent();
        }

        private void btnAltaEjemplar_Click(object sender, EventArgs e)
        {
            DarDeAltaEjemplar darDeAltaEjemplar = new DarDeAltaEjemplar();
            darDeAltaEjemplar.ShowDialog();
        }

        private void btnEliminarEjemplar_Click(object sender, EventArgs e)
        {
            BuscarEjemplar buscarEjemplar = new BuscarEjemplar();
            buscarEjemplar.ShowDialog();

            if (buscarEjemplar.SeleccionoEjemplar())
            {

            }
        }

        private void btnEditarEjemplar_Click(object sender, EventArgs e)
        {
            EditarEjemplar editarEjemplar = new EditarEjemplar();
            editarEjemplar.ShowDialog();
        }

        private void btnBuscarEjemplar_Click(object sender, EventArgs e)
        {
            BuscarEjemplar buscarEjemplar = new BuscarEjemplar();
            buscarEjemplar.ShowDialog();
        }
    }
}
