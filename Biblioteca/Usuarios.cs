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
    public partial class Usuarios : UserControl
    {

        Aplication.Fachada fachada;

        public Usuarios()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            EditarUsuario editarUsuario = new EditarUsuario();
            editarUsuario.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            BuscarUsuario buscarUsuario = new BuscarUsuario();
            buscarUsuario.ShowDialog();
            if (buscarUsuario.EncontroUsuario())
            {
                var usuario = buscarUsuario.ObtenerUsuarioSeleccionado();
                EditarUsuario editarUsuario = new EditarUsuario(usuario);
                editarUsuario.ShowDialog();
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BuscarUsuario buscarUsuario = new BuscarUsuario();
            buscarUsuario.ShowDialog();
            if (buscarUsuario.EncontroUsuario())
            {
                var usuarioEncontrado = buscarUsuario.ObtenerUsuarioSeleccionado();
                fachada.BajaUsuario(usuarioEncontrado.Dni);
                MessageBox.Show("Usuario eliminado correctamente");
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registroUsuario = new RegistrarUsuario();
            registroUsuario.ShowDialog();
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
