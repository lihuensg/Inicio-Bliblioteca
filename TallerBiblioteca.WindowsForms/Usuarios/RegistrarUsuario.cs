using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Common.Excepciones;
using TallerBiblioteca.Aplication.Log;
using TallerBiblioteca.Domain.Common.Excepciones;
using TallerBiblioteca.Domain.Common.IO.Usuarios;

namespace TallerBiblioteca.WindowsForms
{
    public partial class RegistrarUsuario : Form
    {
        readonly FachadaUsuarios fachada;

        public RegistrarUsuario(FachadaUsuarios pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CrearUsuarioDTO usuario = new CrearUsuarioDTO
            {
                Dni = (int)numDNI.Value,
                NombreUsuario = txtNombre.Text,
                Password = txtContraseña.Text,
                Mail = txtMail.Text,
            };

            try
            {
                fachada.AgregarUsuario(usuario, checkAdmin.Checked);
                MessageBox.Show("Usuario registrado correctamente");
                this.Close();
            }
            catch (ExcepcionEmailInvalido)
            {
                MessageBox.Show("Email invalido");
            }
            catch (ExcepcionUsuarioConDniYaExiste)
            {
                MessageBox.Show("Ya existe un usuario con ese DNI");
            }
            catch (ExcepcionUsuarioConMailYaExiste)
            {
                MessageBox.Show("Ya existe un usuario con ese mail");
            }
            catch (ExcepcionUsuarioConNombreDeUsuarioYaExiste)
            {
                MessageBox.Show("Ya existe un usuario con ese nombre de usuario");
            }
            catch (Exception error)
            {
                LogManager.GetLogger().Error(error);

                MessageBox.Show("Error inesperado. Intentalo nuevamente");
            }
        }
    }
}
