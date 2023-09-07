using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Common.IO.Usuarios;

namespace TallerBiblioteca.WindowsForms
{
    public partial class BuscarUsuario : FormularioSeleccion<DatosUsuarioDTO>
    {
        readonly FachadaUsuarios fachada;

        public BuscarUsuario(FachadaUsuarios pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        protected override void OnEsSeleccionCambio(bool pEsSeleccion)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.SetElementoSeleccionado(null);
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.dgvUsuarios.Rows.Clear();
            var buscado = fachada.ObtenerUsuario((int)numDNI.Value);

            if (buscado != null)
            {
                this.SetElementoSeleccionado(buscado);
                this.dgvUsuarios.Rows.Insert(0, buscado.Nombre, buscado.Dni, DateTime.Now,
                    buscado.Puntaje, buscado.Mail);
            }
            else
            {
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
