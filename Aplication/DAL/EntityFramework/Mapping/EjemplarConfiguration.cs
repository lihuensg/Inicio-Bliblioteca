using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;


namespace Aplication.DAL.EntityFramework.Mapping
{
    public class EjemplarConfiguration : EntityTypeConfiguration<Ejemplar>
    {
        public EjemplarConfiguration()
        {
           this.HasKey(pEjemplar => pEjemplar.Id);

            this.Property(pEjemplar => pEjemplar.CodigoInventario)
                .HasMaxLength(100)
                .IsRequired();

           this.Property(pEjemplar => pEjemplar.FechaAlta)
                .IsRequired();

            this.HasRequired(pEjemplar => pEjemplar.Edicion);


        }

    }
}