using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.WindowsForms.Ediciones;
using TallerBiblioteca.WindowsForms.Utils;

namespace TallerBiblioteca.WindowsForms
{
    public partial class BuscarEdicion : Form
    {
        readonly FachadaEdicion fachada;
        public BuscarEdicion(FachadaEdicion pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
            ucEdicion1.SetPuedeEditarLosCampos(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            ucEdicion1.LimpiarCampos();
        }

        private void btnBuscarISBN_Click(object sender, EventArgs e)
        {
            var edicion = fachada.BuscarEdicion(FormateoUtiles.LimpiarGuionesISBN(textISBN.Text));
            if (edicion != null)
            {
                ucEdicion1.SetEdicion(edicion);
            } else
            {
                MessageBox.Show("No se encontro");
            }
        }

        public void SetHabilitarEdicion(bool habilitar)
        {
            btnEditar.Visible = habilitar;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var edicion = ucEdicion1.GetEdicion();
            if (edicion != null)
            {
                using (var form = Program.ServiceProvider.GetRequiredService<EditarEdicion>())
                {
                    this.Hide();
                    form.SetEdicionAEditar(edicion);
                    form.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
