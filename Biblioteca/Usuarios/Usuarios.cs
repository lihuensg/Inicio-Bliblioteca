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
using Microsoft.Extensions.DependencyInjection;

namespace Inicio_Bliblioteca
{
    public partial class Usuarios : UserControl
    {

        readonly Fachada fachada;
        readonly BuscarUsuario buscarUsuarioForm;
        readonly EditarUsuario editarUsuarioForm;

        public Usuarios(Fachada pFachada,
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
                DTOUsuario infoUsuario = fachada.ObtenerUsuario(InformacionDelLogin.DNI.Value);
                lNombre.Text = infoUsuario.Nombre;
                //lUltimoInicio.Text = infoUsuario.
                lPuntaje.Text = infoUsuario.Puntaje.ToString();
                lMail.Text = infoUsuario.Mail;
                lFechaRegistro.Text = infoUsuario.FechaRegistro.ToString();
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
