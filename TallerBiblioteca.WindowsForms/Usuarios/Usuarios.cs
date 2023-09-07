using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Common.IO.Usuarios;
using TallerBiblioteca.WindowsForms;

namespace TallerBiblioteca.WindowsForms
{
    public partial class Usuarios : UserControl
    {

        readonly FachadaUsuarios fachada;
        readonly BuscarUsuario buscarUsuarioForm;
        readonly EditarUsuario editarUsuarioForm;

        public Usuarios(FachadaUsuarios pFachada,
                        BuscarUsuario pBuscarUsuarioForm,
                        EditarUsuario pEditarUsuarioForm)
        {
            InitializeComponent();
            fachada = pFachada;
            buscarUsuarioForm = pBuscarUsuarioForm;
            editarUsuarioForm = pEditarUsuarioForm;
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            editarUsuarioForm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            buscarUsuarioForm.SetEsSeleccion(true);
            buscarUsuarioForm.ShowDialog();
            if (buscarUsuarioForm.SeleccionoElemento())
            {
                var usuario = buscarUsuarioForm.ObtenerElementoSeleccionado();
                editarUsuarioForm.SetUsuario(usuario);
                editarUsuarioForm.ShowDialog();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            buscarUsuarioForm.SetEsSeleccion(true);
            buscarUsuarioForm.ShowDialog();
            if (buscarUsuarioForm.SeleccionoElemento())
            {
                var usuarioEncontrado = buscarUsuarioForm.ObtenerElementoSeleccionado();
                fachada.BajaUsuario(usuarioEncontrado.Dni);
                MessageBox.Show("Usuario eliminado correctamente");
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (var registrarUsuarioForm = Program.ServiceProvider.GetRequiredService<RegistrarUsuario>())
            {
                registrarUsuarioForm.ShowDialog();
            }
        }

        void RefrescarDatos()
        {
            if (InformacionDelLogin.DNI != null)
            {
                DatosUsuarioDTO infoUsuario = fachada.ObtenerUsuario(InformacionDelLogin.DNI.Value);
                lNombre.Text = infoUsuario.Nombre;
                //lUltimoInicio.Text = infoUsuario.
                lPuntaje.Text = infoUsuario.Puntaje.ToString();
                lMail.Text = infoUsuario.Mail;
            }
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {

            RefrescarDatos();

        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            RefrescarDatos();
        }
    }
}
