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
using Aplication.Excepciones.Usuarios;

namespace Inicio_Bliblioteca
{
    public partial class RegistrarPrestamos : Form
    {
        readonly Fachada fachada;
        readonly BuscarEjemplar buscarEjemplarForm;
        readonly BuscarUsuario buscarUsuarioForm;

        public RegistrarPrestamos(BuscarEjemplar pBuscarEjemplar,
                                  Fachada pFachada,
                                  BuscarUsuario pBuscarUsuario)
        {
            InitializeComponent();
            buscarEjemplarForm = pBuscarEjemplar;
            buscarUsuarioForm = pBuscarUsuario;
            fachada = pFachada;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBusUsuario_Click(object sender, EventArgs e)
        {
            buscarUsuarioForm.SetEsSeleccion(true);
            buscarUsuarioForm.ShowDialog();

            if (buscarUsuarioForm.SeleccionoElemento())
            {
                txtDNI.Text = buscarUsuarioForm.ObtenerElementoSeleccionado().Dni.ToString();
            }
        }

        private void btnBuscarEjemplar_Click(object sender, EventArgs e)
        {
            buscarEjemplarForm.SetEsSeleccion(true);
            buscarEjemplarForm.ShowDialog();

            if (buscarEjemplarForm.SeleccionoElemento())
            {
                txtCodigoInventario.Text = buscarEjemplarForm.ObtenerElementoSeleccionado().CodigoInventario;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(txtDNI.Text, out int dni))
            {
                MessageBox.Show("DNI no encontrado");
            }

            try
            {
                DateTime fechaVencimiento = fachada.PrestarEjemplar(dni, txtCodigoInventario.Text);
                MessageBox.Show("Prestamo registrado exitosamente.\n Fecha de vencimiento del prestamo: " + fechaVencimiento.ToString());
            }
            catch (ExcepcionCodigoInventarioInvalido)
            {
                MessageBox.Show("Codigo Inventario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionEjemplarYaPrestado)
            {
                MessageBox.Show("El ejemplar ya esta prestado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionEjemplarNoExiste)
            {
                MessageBox.Show("El ejemplar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionUsuarioNoExiste)
            {
                MessageBox.Show("El usuario no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
