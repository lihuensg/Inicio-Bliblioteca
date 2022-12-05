using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio_Bliblioteca
{
    public partial class Usuarios : UserControl
    {
        public Usuarios()
        {
            InitializeComponent();
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
                EditarUsuario editarUsuario = new EditarUsuario();
                editarUsuario.ShowDialog();
            }
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BuscarUsuario buscarUsuario = new BuscarUsuario();
            buscarUsuario.ShowDialog();
            if (buscarUsuario.EncontroUsuario())
            {
                throw new NotImplementedException();
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarUsuario registroUsuario = new RegistrarUsuario();
            registroUsuario.ShowDialog();
        }
    }
}
