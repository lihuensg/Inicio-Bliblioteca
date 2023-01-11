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
    public partial class BuscarObraAPI : Form
    {
        public BuscarObraAPI()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var filtroPorTitulo = txtTitulo.Text;
            var filtroPorAutor = txtAutor.Text;
            var pFiltros = new Dictionary<string, string>();
            pFiltros.Add("Titulo", filtroPorTitulo);
            pFiltros.Add("Autor", filtroPorAutor);
            var encontrado = ServicesObrasOpenLibrary.Instance.Buscar(pFiltros);

            foreach (var item in encontrado)
            {
                dataGridView1.Rows.Add(item.Titulo,item.Lccn,item.Descripcion,String.Join(", ", item.Generos),item.Autores, String.Join(", " ,item.Ediciones.Select(a => a.AnioEdicion)));
            } 
        }
    }
}
