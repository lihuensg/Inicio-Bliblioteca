using Aplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio_Bliblioteca
{
    public partial class BuscarPrestamo : Form
    {
        public BuscarPrestamo(bool esBuscar = true)
        {
            InitializeComponent();
            if (!esBuscar)
            {
                btnAceptar.Visible = true;
            } 
        }

        private void BuscarPrestamo_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBusUsuario_Click(object sender, EventArgs e)
        {
            BuscarUsuario buscarUsuario = new BuscarUsuario();
            buscarUsuario.ShowDialog();
        }

        private void btnEjemplar_Click(object sender, EventArgs e)
        {
            EliminarEjemplares buscarEjemplar = new EliminarEjemplares();
            buscarEjemplar.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Fachada fachada = new Fachada();
            var listaPrestamos = fachada.PrestamosEntreFechas((int)numericUpDown1.Value, dtFecha1.Value, dtFecha2.Value);
            foreach (var item in listaPrestamos)
            {
                dataGridView1.Rows.Add(item.FechaVencimiento, item.FechaPrestamo, item.Id, item.Nombre, item.CodigoInventario);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
