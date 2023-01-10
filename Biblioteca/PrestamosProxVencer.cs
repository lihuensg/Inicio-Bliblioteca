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

namespace Inicio_Bliblioteca
{
    public partial class PrestamosProxVencer : UserControl
    {
        Fachada fachada;
        public PrestamosProxVencer()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void PrestamosProxVencer_Load(object sender, EventArgs e)
        {
           var prestamosAVencer = fachada.PrestamosProximosAVencer();
            foreach (var prestamo in prestamosAVencer)
            {
                this.dataGridView1.Rows.Add(prestamo.FechaVencimiento, prestamo.FechaPrestamo, prestamo.Id,prestamo.SolicitanteDNI);
            } 
        }
    }
}
