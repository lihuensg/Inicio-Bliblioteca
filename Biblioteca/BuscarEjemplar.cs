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
       List <DTOEjemplarPrestamo> ejemplar1;
        public BuscarEjemplar()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void btnSelecISBN_Click(object sender, EventArgs e)
        {
            try
            {
                ejemplar1 = fachada.ListarEjemplaresConPrestamos(FormateoUtiles.LimpiarGuionesISBN(txtISBN.Text));
                foreach (var item in ejemplar1)
                {
                    dataGridView1.Rows.Add(item.codigoInventario, item.Prestado, item.FechaAlta, item.FechaBaja == DateTime.MinValue ? "-" : item.FechaBaja.ToString());
                }
               
            }
            catch (Exception)
            {

                MessageBox.Show("No se encontro");
            }
        }
    }
}
