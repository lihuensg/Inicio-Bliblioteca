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
    public partial class cambiarContraseña : Form
    {
        Fachada fachada;
        DTOUsuario usuario;
        public cambiarContraseña(DTOUsuario pUsuario = null)
        {
            InitializeComponent();
            fachada = new Fachada();
            usuario = pUsuario;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var DNI = usuario == null ? InformacionDelLogin.DNI.Value : usuario.Dni;
            var usuarioObtenido = fachada.ObtenerUsuario(DNI);
            if (usuarioObtenido != null
                && fachada.LoguearUsuario(usuarioObtenido.Nombre, textContraseñaActual.Text))
            {
                fachada.ModificarDatosUsuario(DNI, new ActualizarUsuario { Password = textContraseñaNueva.Text });
                MessageBox.Show("Contraseña modificada correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario o contraseña es incorrecto");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
