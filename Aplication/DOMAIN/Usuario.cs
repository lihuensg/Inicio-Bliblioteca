using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Excepciones;
using Aplication.Utils;

namespace Aplication
{
    public class Usuario
    {
        public static Usuario Crear(CrearUsuario solicitud)
        {
            Usuario usuario = new Usuario();
            usuario.EsAdministrador = solicitud.EsAdminitrador;
            usuario.FechaRegistro = DateTime.Now;
            usuario.Puntaje = 0;

            if (solicitud.Nombre != null && solicitud.Nombre.Length != 0)
            {
                usuario.NombreUsuario = solicitud.Nombre;
            }

            if (solicitud.Mail != null && solicitud.Mail.Length != 0)
            {

                if (!Validaciones.EsMailValido(solicitud.Mail))
                {
                    throw new ExcepcionEmailInvalido();
                }
                usuario.Mail = solicitud.Mail;
            }

            if (solicitud.Password != null && solicitud.Password.Length != 0)
            {
                usuario.Password = solicitud.Password;
            }

            return usuario;
        }
        public void Actualizar(ActualizarUsuario usuario)
        {
            if (usuario.Nombre != null && usuario.Nombre.Length != 0)
            {
                this.NombreUsuario = usuario.Nombre;
            }

            if (usuario.Mail != null && usuario.Mail.Length != 0)
            {
                
                if (!Validaciones.EsMailValido(usuario.Mail))
                {
                    throw new ExcepcionEmailInvalido();
                }
                this.Mail = usuario.Mail;
            }

            if (usuario.Password != null && usuario.Password.Length != 0)
            {
                this.Password = usuario.Password;
            }
        }
        public bool EsAdministrador { get; set; }

        public int Id { get; set; }
        public int Dni
        {
            get; set;
        }

        public string NombreUsuario
        {
            get; set;

        }

        public string Password
        {
            get; set;

        }

        public string Mail
        {
            get; set;

        }
        public DateTime FechaRegistro
        {
            get; set;

        }

        public int Puntaje
        {
            get; set;
        }

        public virtual List<Prestamo> Prestamos
        {
            get; set;
        }

        public int MaximoDiasHabilesPrestamos()
        {
            int dias = 5;
            dias += this.Puntaje / 5;
            dias = Math.Min(dias, 15);
            return dias;
        }
    }
}