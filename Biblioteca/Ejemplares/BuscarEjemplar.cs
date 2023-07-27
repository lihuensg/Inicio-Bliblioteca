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
using Inicio_Bliblioteca.Utils;

namespace Inicio_Bliblioteca
{
    public partial class BuscarEjemplar : FormularioSeleccion<DTOEjemplar>
    {
        readonly Fachada fachada;
        List<DTOEjemplar> listEjemplares;

        public BuscarEjemplar(Fachada pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        protected override void OnEsSeleccionCambio(bool pEsSeleccion)
        {
            btnSeleccionar.Visible = pEsSeleccion;
        }

        private void btnSelecISBN_Click(object sender, EventArgs e)
        {
            try
            {
                listEjemplares = fachada.ListarEjemplares(FormateoUtiles.LimpiarGuionesISBN(txtISBN.Text));
                foreach (var item in listEjemplares)
                {
                    dataGridView1.Rows.Add(item.CodigoInventario, item.Prestado, item.PrestadoA, item.FechaAlta, item.FechaBaja == DateTime.MinValue ? "-" : item.FechaBaja.ToString());
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se encontro");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // verificar que la lista no sea null
            if (listEjemplares == null || listEjemplares.Count == 0)
            {
                MessageBox.Show("Debe buscar un ejemplar primero");
                return;
            }

            // verificar que haya seleccionado una fila
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }

            // obtener el seleccionado
            this.SetElementoSeleccionado(listEjemplares[dataGridView1.SelectedRows[0].Index]);

            this.Close();
        }
    }
}
