﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplication;
using Aplication.Excepciones;

namespace Inicio_Bliblioteca
{
    public partial class RegistrarPrestamos : Form
    {
        Fachada fachada;
        public RegistrarPrestamos()
        {
            InitializeComponent();
            fachada = new Fachada();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBusUsuario_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtDNI.Text, out int dni) && fachada.ExisteUsuario(dni))
            {
                fachada.CantidadDiaMaximoHabilesDeUsuario(Int32.Parse(txtDNI.Text));
                var fechaVencimiento = DateTime.Now.AddDays(fachada.CantidadDiaMaximoHabilesDeUsuario(Int32.Parse(txtDNI.Text)));
                txtFechaVencimiento.Text = fechaVencimiento.ToString();
            }
            else
            {
                MessageBox.Show("DNI no encontrado");
            }

        }

        private void btnBuscarEjemplar_Click(object sender, EventArgs e)
        {
            if (fachada.ExisteEjemplar(txtCodigoInventario.Text))
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Codigo Inventario no encontrado");
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(txtDNI.Text, out int dni))
            {
                MessageBox.Show("DNI no encontrado");
            }

            try
            {
                fachada.PrestarEjemplar(dni, txtCodigoInventario.Text);
                MessageBox.Show("Prestamo registrado exitosamente");
            }
            catch (ExcepcionCodigoInventarioInvalido)
            {
                MessageBox.Show("Codigo Inventario no encontrado");
            }
            catch (ExcepcionEjemplarYaPrestado)
            {
                MessageBox.Show("El ejemplar ya esta prestado");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
