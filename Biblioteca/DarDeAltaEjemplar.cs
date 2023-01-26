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
    public partial class DarDeAltaEjemplar : Form
    {
        Fachada fachada;
        DTOEdicion edicion1;
        public DarDeAltaEjemplar()
        {
            InitializeComponent();
            fachada = new Fachada();
           
        }

        private void btnBuscarObra_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarEdicion_Click(object sender, EventArgs e)
        {
            try
            {
                edicion1 = fachada.BuscarEdicion(txtISBN.Text);
                MessageBox.Show("ISBN encontrado");
            }
            catch (Exception)
            {

                MessageBox.Show("No se encontro");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            fachada.AgregarEjemplar(new DTOEjemplar { Edicion = edicion1, FechaAlta = DateTime.Now, codigoInventario = "2" });
            MessageBox.Show("Guardado correctamente");
        }
    }
}
