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
        readonly Fachada fachada;
        public PrestamosProxVencer(Fachada pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void PrestamosProxVencer_Load(object sender, EventArgs e)
        {
            //esto lo realizamos para esperar a que este logeado es decir que no se ejecute en el diseñador
            if (InformacionDelLogin.DNI != null)
            {
                ActualizarPrestamos();
            }
        }

        private void ActualizarPrestamos()
        {
            this.dataGridView1.Rows.Clear();
            var prestamosAVencer = fachada.PrestamosProximosAVencer();
            foreach (var prestamo in prestamosAVencer)
            {
                this.dataGridView1.Rows.Add(prestamo.FechaVencimiento, prestamo.FechaPrestamo, prestamo.Id, prestamo.SolicitanteDNI);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            ActualizarPrestamos();
        }
    }
}
