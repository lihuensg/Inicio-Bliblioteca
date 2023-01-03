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
        public cambiarContraseña()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var usuarioObtenido = fachada.ObtenerUsuario(InformacionDelLogin.DNI.Value);
            if (fachada.LoguearUsuario(usuarioObtenido.Nombre, textContraseñaActual.Text))
            {
                fachada.ModificarDatosUsuario(InformacionDelLogin.DNI.Value, new DTOUsuario { Password = textContraseñaNueva.Text });
                MessageBox.Show("Contraseña modificada correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Contraseña actual incorrecta");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
