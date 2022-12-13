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
    public partial class DarDeAltaEjemplar : Form
    {
        public DarDeAltaEjemplar()
        {
            InitializeComponent();
        }

        private void btnBuscarObra_Click(object sender, EventArgs e)
        {
            BuscarOSeleccionarObra buscarOSeleccionarObra = new BuscarOSeleccionarObra();
            buscarOSeleccionarObra.ShowDialog();

            if (buscarOSeleccionarObra.SelecionoObra())
            {
                var obra = buscarOSeleccionarObra.Selecionada();
                SeleccionarEdicion seleccionarEdicion = new SeleccionarEdicion();
                throw new NotImplementedException();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
