using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework.Mapping
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public void Configure()
        {
            this.HasKey(pUsuario => pUsuario.Id);

            this.Property(pUsuario => pUsuario.NombreUsuario)
                .HasMaxLength(20)
                .IsRequired();

            this.Property(pUsuario => pUsuario.Dni)
                .IsRequired();

            this.Property(pUsuario => pUsuario.Password)
                .HasMaxLength(150)
                .IsRequired();

            this.Property(pUsuario => pUsuario.Mail)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(pUsuario => pUsuario.FechaRegistro)
                .IsRequired();

            this.Property(pUsuario => pUsuario.Puntaje)
                .IsRequired();

            this.HasMany(pUsuario => pUsuario.Prestamos);

        }

    }
}