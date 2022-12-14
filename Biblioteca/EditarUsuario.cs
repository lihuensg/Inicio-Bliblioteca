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
    public partial class EditarUsuario : Form
    {
        Fachada fachada;
        DTOUsuario usuario;

        public EditarUsuario(DTOUsuario pUsuario = null)
        {
            InitializeComponent();
            fachada = new Fachada();
            usuario = pUsuario;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {
            if (InformacionDelLogin.DNI != null && usuario == null)
            {
                DTOUsuario usuarioObtenido = fachada.ObtenerUsuario(InformacionDelLogin.DNI.Value);
                textBox1.Text = usuarioObtenido.Nombre;
                textBox2.Text = usuarioObtenido.Mail;
            }
            else if (usuario != null)
            {
                textBox1.Text = usuario.Nombre;
                textBox2.Text = usuario.Mail;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DTOUsuario usuarioEditado = new DTOUsuario { Nombre = textBox1.Text, Mail = textBox2.Text };
            if (usuario == null)
            {
                fachada.ModificarDatosUsuario(InformacionDelLogin.DNI.Value, usuarioEditado);
            }
            else
            {
                fachada.ModificarDatosUsuario(usuario.Dni, usuarioEditado);
            }
            MessageBox.Show("Modificado correctamente");
        }

        private void btnCambioContraseña_Click(object sender, EventArgs e)
        {
            var cambioContraseña = new cambiarContraseña(usuario);
            cambioContraseña.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
