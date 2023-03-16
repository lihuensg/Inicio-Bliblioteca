using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework.Mapping
{
    public class NotificacionVencimientoPrestamosConfiguration: EntityTypeConfiguration<NotificacionVencimientoPrestamo>
    {
        public void Configure()
        {
            this.HasKey(pNotificacion => pNotificacion.Id);

            this.Property(pNotifiacion => pNotifiacion.DiasAnteracion).IsRequired();
           
            this.HasRequired(pNotificacion => pNotificacion.Prestamo);
          

        }

    }
}