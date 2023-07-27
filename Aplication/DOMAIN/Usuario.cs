using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Excepciones;
using Aplication.Servicios.Seguridad;
using Aplication.Servicios.Tiempo;
using Aplication.Utils;

namespace Aplication
{
    public class Usuario
    {
        public static Usuario Crear(CrearUsuario solicitud,
                                    IHashingManager hashingManager,
                                    IDateTimeProvider dateTimeProvider)
        {
            if (solicitud == null) throw new ArgumentNullException(nameof(solicitud));
            if (hashingManager == null) throw new ArgumentNullException(nameof(hashingManager));
            if (dateTimeProvider == null) throw new ArgumentNullException(nameof(dateTimeProvider));

            Usuario usuario = new Usuario();

            usuario.Dni = solicitud.Dni;
            usuario.EsAdministrador = solicitud.EsAdminitrador;
            usuario.FechaRegistro = dateTimeProvider.Now;
            usuario.Puntaje = 0;

            if (solicitud.Nombre != null && solicitud.Nombre.Length != 0)
            {
                usuario.NombreUsuario = solicitud.Nombre;
            }
            else
            {
                throw new ArgumentException(nameof(solicitud.Nombre));
            }

            if (solicitud.Mail != null && solicitud.Mail.Length != 0)
            {
                if (!Validaciones.EsMailValido(solicitud.Mail))
                {
                    throw new ExcepcionEmailInvalido();
                }
                usuario.Mail = solicitud.Mail;
            }
            else
            {
                throw new ArgumentException(nameof(solicitud.Mail));
            }

            if (solicitud.Password != null && solicitud.Password.Length != 0)
            {
                usuario.Password = hashingManager.Hash(solicitud.Password);
            }
            else
            {
                throw new ArgumentException(nameof(solicitud.Password));
            }

            return usuario;
        }

        public void Actualizar(ActualizarUsuario usuario, IHashingManager hashingManager)
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
                this.Password = hashingManager.Hash(usuario.Password);
            }
        }

        /// <summary>
        /// Devuelve la cantidad de días que se puede extender el préstamo,
        //  en base al puntaje del usuario.
        /// </summary>
        public int MaximoDiasHabilesPrestamos()
        {

            int dias = Constantes.Prestamo.DiasBaseDePrestamo;

            if (Puntaje > 0)
            {
                dias += this.Puntaje / Constantes.Puntaje.PuntajeNecesarioParaExtenderElPrestamoUnDia;
                dias = Math.Min(dias, Constantes.Prestamo.DiasMaximoDePrestamo);
            }

            return dias;
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
    }
}