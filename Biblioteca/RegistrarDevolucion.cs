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
using Aplication.Excepciones;
using Aplication.Excepciones.Ejemplares;

namespace Inicio_Bliblioteca
{
    public partial class RegistrarDevolucion : Form
    {
        Fachada fachada;
        public RegistrarDevolucion()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                fachada.DevolverEjemplar(textCodigoInventario.Text, !checkBoxMalEstado.Checked);
                MessageBox.Show("Devuelto exitosamente");
            }
            catch (ExcepcionCodigoInventarioInvalido)
            {
                MessageBox.Show("Codigo de inventario invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionEjemplarNoEstaPrestado)
            {
                MessageBox.Show("Ejemplar no esta prestado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEjemplar buscarEjemplar = new BuscarEjemplar(true);
            buscarEjemplar.ShowDialog();

            if (buscarEjemplar.SeleccionoEjemplar())
            {
                textCodigoInventario.Text = buscarEjemplar.ObtenerEjemplarSeleccionado().codigoInventario;
            }
        }
    }
}
