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
    public partial class Usuario : Form
    {
        string nombre_usuario;
        public Usuario(string nombre)
        {
            InitializeComponent();
            nombre_usuario = nombre;
            usuarios1.BringToFront();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
       
        }

        private void lUsuarios_Click(object sender, EventArgs e)
        {
            usuarios1.BringToFront();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            prestamosYDevoluciones1.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            prestamosProxVencer1.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ejemplares1.BringToFront();
        }
    }
}
