using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Common.Excepciones.Ediciones;
using TallerBiblioteca.Aplication.Common.IO.Edicion;
using TallerBiblioteca.Aplication.LibrosRemotos;
using TallerBiblioteca.WindowsForms.Utils;

namespace TallerBiblioteca.WindowsForms
{
    public partial class CrearEdicion : Form
    {
        readonly IServicioEdicionRemota serviciosEdicion;
        readonly FachadaEdicion fachada;

        public CrearEdicion(FachadaEdicion pFachada, IServicioEdicionRemota pServiciosEdicion)
        {
            InitializeComponent();

            fachada = pFachada;
            serviciosEdicion = pServiciosEdicion;
        }

        private void btnBuscarEdicion_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<BuscarEdicion>())
            {
                form.ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ucEdicion1.LimpiarCampos();
            this.Close();
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
            } else
            {
                MessageBox.Show($"No se encontraron metadatos para el ISBN {isbn}");
            }

            ucEdicion1.SetPuedeEditarLosCampos(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                fachada.AgregarEdicion(ucEdicion1.GetEdicion());
                MessageBox.Show("Edicion guardada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (ExcepcionEdicionYaExiste)
            {
                MessageBox.Show("Ya existe una edicion con el ISBN ingresado. La puedes editar en la ventana 'Editar Edicion'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (Exception ex)
            {
                // TODO: Log
                MessageBox.Show($"Ocurrió un error al guardar la edicion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
