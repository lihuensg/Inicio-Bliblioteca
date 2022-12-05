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
    public partial class Inicio : Form
    {
        string Usuario = "Pata";
        string Contraseña = "Pata";
        public Inicio()
        {
            InitializeComponent();
        }


        private void botSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botCancelar_Click_1(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtUsuario.Focus();
            return;
        }

        private void botAceptar_Click_1(object sender, EventArgs e)
        {
            if (txtUsuario.Text != Usuario || txtContraseña.Text != Contraseña)
            {
                if (txtUsuario.Text != Usuario)
                {
                    MessageBox.Show("Usuario Incorrecto");
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                    return;
                }
                if (txtContraseña.Text != Contraseña)
                {
                    MessageBox.Show("Contraseña Incorrecto");
                    txtContraseña.Clear();
                    txtContraseña.Focus();
                    return;
                }
            }
            else
            {
                string nombre = txtUsuario.Text;
                txtUsuario.Clear();
                txtContraseña.Clear();
                this.Hide();               
                using (Usuario ventanaUsuario = new Usuario(nombre))
                    ventanaUsuario.ShowDialog();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
