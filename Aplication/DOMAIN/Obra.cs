using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class Obra
    {

        public int Id { get; set; }
        public string Titulo
        {
            get; set;
        }

        public string Lccn
        {
            get; set;
        }

        public string Descripcion
        {
            get; set;
        }

        public Obra()
        {
        }

        public string autores 
        {
            get; set;
        }
    }
}