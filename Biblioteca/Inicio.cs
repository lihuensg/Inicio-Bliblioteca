using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inicio_Bliblioteca.Ediciones;

namespace Inicio_Bliblioteca
{
    public partial class Inicio : Form
    {
        readonly PrestamosProxVencer prestamosProxVencerControl;
        readonly PrestamosYDevoluciones prestamosYDevolucionesControl;
        readonly Usuarios usuariosControl;
        readonly Ejemplares ejemplaresControl;
        readonly EdicionesNavegacion ucEdicionesNavControl;

        public Inicio(PrestamosProxVencer pPrestamosProxVencerControl,
                       PrestamosYDevoluciones pPrestamosYDevolucionesControl,
                       Usuarios pUsuariosControl,
                       Ejemplares pEjemplaresControl,
                       EdicionesNavegacion pUcEdicionesNavControl)
        {
            InitializeComponent();
            prestamosProxVencerControl = pPrestamosProxVencerControl;
            prestamosYDevolucionesControl = pPrestamosYDevolucionesControl;
            usuariosControl = pUsuariosControl;
            ejemplaresControl = pEjemplaresControl;
            ucEdicionesNavControl = pUcEdicionesNavControl;

            // agregar controles al panel
            panelCuerpo.Controls.Add(prestamosProxVencerControl);
            panelCuerpo.Controls.Add(prestamosYDevolucionesControl);
            panelCuerpo.Controls.Add(usuariosControl);
            panelCuerpo.Controls.Add(ejemplaresControl);
            panelCuerpo.Controls.Add(ucEdicionesNavControl);

            // expandir al tamaño del panel
            prestamosProxVencerControl.Dock = DockStyle.Fill;
            prestamosYDevolucionesControl.Dock = DockStyle.Fill;
            usuariosControl.Dock = DockStyle.Fill;
            ejemplaresControl.Dock = DockStyle.Fill;
            ucEdicionesNavControl.Dock = DockStyle.Fill;

            // mostrar usuario por defecto
            usuariosControl.BringToFront();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            usuariosControl.BringToFront();
        }

        private void btnPrestamosYDevoluciones_Click(object sender, EventArgs e)
        {
            prestamosYDevolucionesControl.BringToFront();
        }

        private void btnEdiciones_Click(object sender, EventArgs e)
        {
            ucEdicionesNavControl.BringToFront();
        }

        private void btnPrestamosProxVencer_Click(object sender, EventArgs e)
        {
            prestamosProxVencerControl.BringToFront();
        }

        private void btnEjemplares_Click(object sender, EventArgs e)
        {
            ejemplaresControl.BringToFront();
        }
    }
}
