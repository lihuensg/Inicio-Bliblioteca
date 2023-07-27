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
    public partial class BuscarUsuario : FormularioSeleccion<DTOUsuario>
    {
        readonly Fachada fachada;

        public BuscarUsuario(Fachada pFachada)
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
                this.dgvUsuarios.Rows.Insert(0, buscado.Nombre, buscado.Dni, buscado.FechaRegistro,
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
