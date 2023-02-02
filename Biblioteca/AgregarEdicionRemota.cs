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

namespace Inicio_Bliblioteca
{
    public partial class AgregarEdicionRemota : Form
    {
        Fachada fachada;
        List<DTOEdicion> ediciones;
        
        public AgregarEdicionRemota()
        {
            InitializeComponent();
            fachada = new Fachada();
            ediciones = new List<DTOEdicion>();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var filtorPorISBN = txtISBN.Text;
            var pFiltros = new Dictionary<string, string>();
            pFiltros.Add("ISBN", filtorPorISBN);
            DTOEdicion item = ServiceEdicionesOpenLibrary.Instance.Buscar(pFiltros);
            ediciones.Add(item);

            dataGridView1.Rows.Add(item.Isbn, item.AnioEdicion, item.NumeroPaginas, item.FechaPublicacion, item.Obra.Titulo, item.Portada);

            if (dataGridView1.Rows.Count > 0)
            {
                btnAgregarTodos.Enabled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void txtAutor_TextChanged(object sender, EventArgs e) {

        }
        private void btnAgregarTodos_Click(object sender, EventArgs e) {
            foreach(var edicion in ediciones) {
                fachada.AgregarEdicion(edicion);
            }
            MessageBox.Show("Agregados correctamente");
        }
    }
}