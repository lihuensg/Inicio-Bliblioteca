﻿using System;
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
        public BuscarPrestamo()
        {
            InitializeComponent();
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
            BuscarEjemplar buscarEjemplar = new BuscarEjemplar();
            buscarEjemplar.ShowDialog();
        }
    }
}
