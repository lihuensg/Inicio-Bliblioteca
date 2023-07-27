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
    public partial class EditarUsuario : Form
    {
        readonly Fachada fachada;
        readonly CambiarContraseña cambiarContraseñaForm;
        DTOUsuario usuario = null;

        public EditarUsuario(Fachada pFachada,
                             CambiarContraseña pCmbiarContraseñaForm)
        {
            InitializeComponent();
            fachada = pFachada;
            cambiarContraseñaForm = pCmbiarContraseñaForm;
        }

        public void SetUsuario(DTOUsuario pUsuario)
        {
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

                if (usuarioObtenido != null)
                {
                    textBox1.Text = usuarioObtenido.Nombre;
                    textBox2.Text = usuarioObtenido.Mail;
                }
                else
                {
                    LogManager.GetLogger().Error("Error lógico: El usuario logeado deberia exisitir");
                }
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
            ActualizarUsuario usuarioEditado = new ActualizarUsuario { Nombre = textBox1.Text, Mail = textBox2.Text };
            try
            {
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
            catch (ExcepcionEmailInvalido)
            {
                MessageBox.Show("Email invalido");
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

        private void btnCambioContraseña_Click(object sender, EventArgs e)
        {
            cambiarContraseñaForm.SetDni(usuario?.Dni);
            cambiarContraseñaForm.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
