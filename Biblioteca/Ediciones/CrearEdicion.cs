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

namespace Inicio_Bliblioteca
{
    public partial class CrearEdicion : Form
    {
        readonly IServiciosEdicion serviciosEdicion;
        readonly Fachada fachada;

        public CrearEdicion(Fachada pFachada, IServiciosEdicion pServiciosEdicion)
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
            }
            else
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
            }
            catch (ExcepcionEdicionYaExiste)
            {
                MessageBox.Show("Ya existe una edicion con el ISBN ingresado. La puedes editar en la ventana 'Editar Edicion'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // TODO: Log
                MessageBox.Show($"Ocurrió un error al guardar la edicion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
