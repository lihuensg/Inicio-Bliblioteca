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
    public partial class BuscarUsuario : Form
    {
        Fachada fachada;
        DTOUsuario usuarioObtenido = null;
        public BuscarUsuario()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        public bool EncontroUsuario()
        {
            return usuarioObtenido != null;
        }

        public DTOUsuario ObtenerUsuarioSeleccionado()
        {
            return usuarioObtenido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            usuarioObtenido = null;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.dgvUsuarios.Rows.Clear();
            usuarioObtenido = fachada.ObtenerUsuario((int)numDNI.Value);

            if (usuarioObtenido != null)
            {
                this.dgvUsuarios.Rows.Insert(0, usuarioObtenido.Nombre, usuarioObtenido.Dni, usuarioObtenido.FechaRegistro,
                    usuarioObtenido.Puntaje, usuarioObtenido.Mail);
            } else {
                MessageBox.Show("No se encontro usuario con ese DNI");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
