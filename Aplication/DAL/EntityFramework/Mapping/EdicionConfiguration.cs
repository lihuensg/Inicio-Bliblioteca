using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework.Mapping
{
    public class EdicionConfiguration : EntityTypeConfiguration<Edicion>
    {
        public EdicionConfiguration()
        {
            // Esta configuración es permisiva ya que el bibliotecario puede modificarlo

            this.HasKey(pEdicion => pEdicion.Id);

            this.Property(pEdicion => pEdicion.Isbn)
                .IsRequired();

            this.Property(pEdicion => pEdicion.NumeroPaginas)
                .IsRequired();

            /*
            this.Property(pEdicion => pEdicion.AñoEdicion);

            this.Property(pEdicion => pEdicion.Portada);

            this.Property(pEdicion => pEdicion.Titulo);

            this.Property(pEdicion => pEdicion.Descripcion);

            this.Property(pEdicion => pEdicion.Autores);
            */
        }

    }
}