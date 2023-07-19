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
using Aplication.Excepciones.Ediciones;
using Inicio_Bliblioteca.Utils;

namespace Inicio_Bliblioteca
{
    public partial class DarDeAltaEjemplar : Form
    {
        Fachada fachada;
        DTOEdicion edicion;
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
            edicion = fachada.BuscarEdicion(FormateoUtiles.LimpiarGuionesISBN(txtISBN.Text));

            if (edicion != null)
            {
                MessageBox.Show("ISBN encontrado");
                btnAceptar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                fachada.AgregarEjemplar(new Aplication.Contratos.Ejemplar.AgregarEjemplar
                {
                    ISBNEdicion = edicion.Isbn,
                    CantidadEjemplares = (int)numericCantidad.Value,
                });
            }
            catch (ExcepcionEdicionNoExiste)
            {
                MessageBox.Show("No se encontro la edicion");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar");
            }

            MessageBox.Show("Guardado correctamente");
        }

        private void DarDeAltaEjemplar_Load(object sender, EventArgs e)
        {

        }
    }
}
