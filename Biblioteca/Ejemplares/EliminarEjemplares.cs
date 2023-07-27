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
using Aplication.Excepciones;
using Inicio_Bliblioteca.Utils;

namespace Inicio_Bliblioteca
{
    public partial class EliminarEjemplares : Form
    {
        readonly Fachada fachada;
        List<DTOEjemplar> ejemplares;

        public EliminarEjemplares(Fachada pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnSelcObra_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSelecISBN_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            actualizarListaEjemplares(FormateoUtiles.LimpiarGuionesISBN(txtISBN.Text));
        }

        private void actualizarListaEjemplares(string isbn)
        {
            dataGridView1.Rows.Clear();
            try
            {
                ejemplares = fachada.ListarEjemplares(isbn);
                foreach (var item in ejemplares)
                {
                    dataGridView1.Rows.Add(item.CodigoInventario, item.Prestado, item.FechaAlta, item.FechaBaja == DateTime.MinValue ? "-" : item.FechaBaja.ToString());
                }

            }
            catch (Exception)
            {

                MessageBox.Show("No se encontro");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                for (int i = 0; i < selectedCellCount; i++)
                {
                    var ejemplar = ejemplares[dataGridView1.SelectedCells[i].RowIndex];
                    try
                    {
                        fachada.BajaEjemplar(ejemplar.CodigoInventario);
                    }
                    catch (ExcepcionCodigoInventarioInvalido)
                    {
                        MessageBox.Show("El codigo de inventario no es valido");
                    }
                }

                actualizarListaEjemplares(FormateoUtiles.LimpiarGuionesISBN(txtISBN.Text));
            }
            else
            {
                MessageBox.Show("No seleccionaste");
            }
        }
    }
}
