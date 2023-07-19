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
using Inicio_Bliblioteca.Utils;

namespace Inicio_Bliblioteca
{
    public partial class BuscarEdicion : Form
    {
        Fachada fachada;
        public BuscarEdicion()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarObra_Click(object sender, EventArgs e)
        {
            BuscarOSeleccionarObra buscarOSeleccionarObra = new BuscarOSeleccionarObra();
            buscarOSeleccionarObra.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarISBN_Click(object sender, EventArgs e)
        {
            var edicion = fachada.BuscarEdicion(FormateoUtiles.LimpiarGuionesISBN(textISBN.Text));
            if (edicion != null)
            {
                dgvEdicion.Rows.Add(edicion.Isbn, edicion.AnioEdicion, edicion.NumeroPaginas, edicion.Portada, edicion.FechaPublicacion);
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
