﻿using Aplication;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class Login : Form
    {

        readonly Fachada fachada;

        public Login(Fachada pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void botSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botCancelar_Click_1(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtUsuario.Focus();
            return;
        }

        private void botAceptar_Click_1(object sender, EventArgs e)
        {
            if (fachada.LoguearUsuario(txtUsuario.Text, txtContraseña.Text))
            {
                //MessageBox.Show("Logueado correctamente");

                string nombre = txtUsuario.Text;

                if (fachada.EsUsuarioAdmin(nombre))
                {
                    InformacionDelLogin.DNI = fachada.ObtenerUsuario(txtUsuario.Text).Dni;
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                    this.Hide();
                    using (var form = Program.ServiceProvider.GetRequiredService<Inicio>())
                    {
                        form.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No pudo acceder porque no es administrador");
                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecta");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (var registrarUsuarioForm = Program.ServiceProvider.GetRequiredService<RegistrarUsuario>())
            {
                registrarUsuarioForm.ShowDialog();
            }
        }
    }
}
