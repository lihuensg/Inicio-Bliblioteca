using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework.Mapping
{
    public class PrestamoConfiguration : EntityTypeConfiguration<Prestamo>
    {
        public PrestamoConfiguration()
        {
            this.HasKey(pPrestamo => pPrestamo.Id);

            this.Property(pPrestamo => pPrestamo.FechaPrestamo)
                .IsRequired();

            this.Property(pPrestamo => pPrestamo.FechaDevolucion);

            this.Property(pPrestamo => pPrestamo.FechaVencimiento)
                .IsRequired();

            this.HasRequired(pPrestamo => pPrestamo.Solicitante);

            this.HasRequired(pPrestamo => pPrestamo.Ejemplar);
        }

    }
}