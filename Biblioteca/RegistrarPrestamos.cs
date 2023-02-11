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
            if (fachada.ExisteUsuario(Int32.Parse (txtDNI.Text)))
            {
                fachada.CantidadDiaMaximoHabilesDeUsuario(Int32.Parse(txtDNI.Text));
                var fechaVencimiento = DateTime.Now.AddDays(fachada.CantidadDiaMaximoHabilesDeUsuario(Int32.Parse(txtDNI.Text)));
                txtFechaVencimiento.Text = fechaVencimiento.ToString();
            }

            else
            {
                MessageBox.Show("DNI no encontrado");
            }
    
        }

        private void btnBuscarEjemplar_Click(object sender, EventArgs e)
        {
            if (fachada.ExisteEjemplar(txtCodigoInventario.Text))
            {
                btnAceptar.Enabled = true;
            }

            else
            {
                MessageBox.Show("Codigo Inventario no encontrado");
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            fachada.PrestarEjemplar(Int32.Parse(txtDNI.Text), txtCodigoInventario.Text);
            MessageBox.Show("Prestamo registrado exitosamente");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
