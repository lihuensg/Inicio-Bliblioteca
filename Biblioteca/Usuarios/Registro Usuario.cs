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

namespace Inicio_Bliblioteca
{
    public partial class Registro_Usuario : Form
    {
        readonly Fachada fachada;
        public Registro_Usuario(Fachada pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            CrearUsuario usuario = new CrearUsuario
            {
                Dni = (int)numDNI.Value,
                Nombre = txtUsuario.Text,
                Password = txtContraseña.Text,
                Mail = texEmail.Text,
            };

            try
            {
                fachada.AgregarUsuario(usuario, false);
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
                Aplication.LOG.LogManager.GetLogger().Error(error);

                MessageBox.Show("Error inesperado. Intentalo nuevamente");
            }
        }

        private void botCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
