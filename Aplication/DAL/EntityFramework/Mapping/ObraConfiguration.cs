using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework.Mapping
{
    public class ObraConfiguration : EntityTypeConfiguration<Obra>
    {
        public  ObraConfiguration()
        {
            this.HasKey(pObra => pObra.Id);

            this.Property(pObra => pObra.Titulo)
                .IsRequired();

            this.Property(pObra => pObra.Lccn)
                .IsRequired();

            this.Property(pObra => pObra.Descripcion)
                .IsRequired();

        }

    }
}