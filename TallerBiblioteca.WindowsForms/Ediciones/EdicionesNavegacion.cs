using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerBiblioteca.WindowsForms.Ediciones
{
    public partial class EdicionesNavegacion : UserControl
    {
        readonly BuscarEdicion buscarEdicion;
        readonly CrearEdicion crearEdicion;

        public EdicionesNavegacion(BuscarEdicion pBuscarEdicion, CrearEdicion pCrearEdicion)
        {
            InitializeComponent();

            this.buscarEdicion = pBuscarEdicion;
            this.crearEdicion = pCrearEdicion;
        }

        private void btnCrearEdicion_Click(object sender, EventArgs e)
        {
            crearEdicion.ShowDialog();
        }

        private void btnBuscarEdicion_Click(object sender, EventArgs e)
        {
            buscarEdicion.SetHabilitarEdicion(false);
            buscarEdicion.Text = "Buscar Edicion";
            buscarEdicion.ShowDialog();
        }

        private void btnEditarEdicion_Click(object sender, EventArgs e)
        {
            buscarEdicion.SetHabilitarEdicion(true);
            buscarEdicion.Text = "Buscar Edicion a editar";
            buscarEdicion.ShowDialog();
        }

        private void btnEliminarEdicion_Click(object sender, EventArgs e)
        {
            buscarEdicion.Text = "Buscar Edicion a eliminar";
            buscarEdicion.ShowDialog();
        }
    }
}
