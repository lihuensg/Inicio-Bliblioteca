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
using Aplication.Excepciones.Ediciones;
using Aplication.Servicios.LibrosRemotos;
using Inicio_Bliblioteca.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Inicio_Bliblioteca.Ediciones
{
    public partial class EditarEdicion : Form
    {
        readonly IServiciosEdicion serviciosEdicion;
        readonly Fachada fachada;

        public EditarEdicion(Fachada pFachada, IServiciosEdicion pServiciosEdicion)
        {
            InitializeComponent();

            fachada = pFachada;
            serviciosEdicion = pServiciosEdicion;
        }

        public void SetEdicionAEditar(DTOEdicion pEdicion)
        {
            ucEdicion1.SetEdicion(pEdicion);
        }

        private async void btnBuscarMetadatos_Click(object sender, EventArgs e)
        {
            ucEdicion1.SetPuedeEditarLosCampos(false);

            var edicion = ucEdicion1.GetEdicion();
            string isbn = FormateoUtiles.LimpiarGuionesISBN(edicion.Isbn);

            DTOEdicion edicionRemota = await serviciosEdicion.BuscarPorISBNAsync(isbn);

            if (edicionRemota != null)
            {
                ucEdicion1.SetEdicion(edicionRemota);
            }
            else
            {
                MessageBox.Show($"No se encontraron metadatos para el ISBN {isbn}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            ucEdicion1.SetPuedeEditarLosCampos(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var edicion = ucEdicion1.GetEdicion();
                fachada.ModificarEdicion(edicion);
                MessageBox.Show("Se edito correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
