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
    public partial class RegistrarDevolucion : Form
    {
        Fachada fachada;
        public RegistrarDevolucion()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void btnBuscarCodInv_Click(object sender, EventArgs e)
        {
            if (fachada.ExisteEjemplar(textCodigoInventario.Text))
            {
                if (fachada.EstaPrestadoEjemplar(textCodigoInventario.Text))
                {
                    btnDevolver.Enabled = true;
                    MessageBox.Show("Encontrado correctamente");
                }
                else
                {
                    btnDevolver.Enabled = false;
                    MessageBox.Show("Ejemplar no esta prestado");
                }
            }
            else
            {
                btnDevolver.Enabled = false;
                MessageBox.Show("Ejemplar no existe");
            }
            
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            fachada.DevolverEjemplar(textCodigoInventario.Text, !checkBoxMalEstado.Checked);
            MessageBox.Show("Devuelto exitosamente");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
