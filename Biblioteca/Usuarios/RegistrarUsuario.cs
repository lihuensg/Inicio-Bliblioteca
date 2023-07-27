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
using Aplication.Excepciones.Usuarios;
using Aplication.LOG;

namespace Inicio_Bliblioteca
{
    public partial class RegistrarUsuario : Form
    {
        readonly Fachada fachada;

        public RegistrarUsuario(Fachada pFachada)
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
            CrearUsuario usuario = new CrearUsuario
            {
                Dni = (int)numDNI.Value,
                Nombre = txtNombre.Text,
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
