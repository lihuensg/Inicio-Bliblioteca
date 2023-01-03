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
    public partial class RegistrarUsuario : Form
    {
        Fachada fachada;
        public RegistrarUsuario()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DTOUsuario usuario = new DTOUsuario
            {
                Dni = (int)numDNI.Value,
                Nombre = txtNombre.Text,
                Password = txtContraseña.Text,
                Mail = txtMail.Text,
                FechaRegistro = DateTime.Now,
                Puntaje = 0,
            };

            fachada.AgregarUsuario(usuario, checkAdmin.Checked);
            MessageBox.Show("Usuario registrado correctamente");
            this.Close();
        }
    }
}
