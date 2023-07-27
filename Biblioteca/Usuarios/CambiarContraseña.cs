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
using Aplication.Excepciones.Usuarios;

namespace Inicio_Bliblioteca
{
    public partial class CambiarContraseña : Form
    {
        readonly Fachada fachada;
        int? usuarioDni = null;

        public CambiarContraseña(Fachada pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Setea el DNI del usuario que se quiere cambiar la contraseña.
        /// </summary>
        /// <param name="pDni">DNI del usuario, pasar null para usar el usuario logeado</param>
        public void SetDni(int? pDni)
        {
            usuarioDni = pDni;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var DNI = usuarioDni == null ? InformacionDelLogin.DNI.Value : usuarioDni.Value;
            var usuarioObtenido = fachada.ObtenerUsuario(DNI);
            if (usuarioObtenido != null
                && fachada.LoguearUsuario(usuarioObtenido.Nombre, textContraseñaActual.Text))
            {
                try
                {
                    fachada.ModificarDatosUsuario(DNI, new ActualizarUsuario { Password = textContraseñaNueva.Text });
                }
                catch (ExcepcionUsuarioNoExiste)
                {
                    MessageBox.Show("El usuario no existe");
                }
                catch (ExcepcionUsuarioConNombreDeUsuarioYaExiste)
                {
                    MessageBox.Show("El nombre de usuario ya existe");
                }
                catch (ExcepcionUsuarioConMailYaExiste)
                {
                    MessageBox.Show("El mail ya existe");
                }

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
