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
    public partial class BuscarEjemplar : Form
    {
        Fachada fachada;
        List<DTOEjemplar> listEjemplares;
        DTOEjemplar seleccionado = null;

        public BuscarEjemplar(bool EsSeleccionDeEjemplar = false)
        {
            InitializeComponent();
            fachada = new Fachada();

            if (EsSeleccionDeEjemplar)
            {
                btnSeleccionar.Visible = true;
            }
        }

        public bool SeleccionoEjemplar()
        {
            return seleccionado != null;
        }

        public DTOEjemplar ObtenerEjemplarSeleccionado()
        {
            return seleccionado;
        }

        private void btnSelecISBN_Click(object sender, EventArgs e)
        {
            try
            {
                listEjemplares = fachada.ListarEjemplares(FormateoUtiles.LimpiarGuionesISBN(txtISBN.Text));
                foreach (var item in listEjemplares)
                {
                    dataGridView1.Rows.Add(item.codigoInventario, item.Prestado, item.FechaAlta, item.FechaBaja == DateTime.MinValue ? "-" : item.FechaBaja.ToString());
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se encontro");
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // verificar que haya seleccionado una fila
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una fila");
                return;
            }

            // obtener el seleccionado
            seleccionado = listEjemplares[dataGridView1.SelectedRows[0].Index];

            this.Close();
        }
    }
}
