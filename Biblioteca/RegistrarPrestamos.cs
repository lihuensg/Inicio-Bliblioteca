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
        Fachada fachada;
        public RegistrarPrestamos()
        {
            InitializeComponent();
            fachada = new Fachada();
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
            BuscarUsuario buscarUsuario = new BuscarUsuario();
            buscarUsuario.ShowDialog();

            if (buscarUsuario.SeleccionoUsuario())
            {
                txtDNI.Text = buscarUsuario.ObtenerUsuarioSeleccionado().Dni.ToString();
            }
        }

        private void btnBuscarEjemplar_Click(object sender, EventArgs e)
        {
            BuscarEjemplar buscarEjemplar = new BuscarEjemplar(true);
            buscarEjemplar.ShowDialog();

            if (buscarEjemplar.SeleccionoEjemplar())
            {
                txtCodigoInventario.Text = buscarEjemplar.ObtenerEjemplarSeleccionado().codigoInventario;
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
