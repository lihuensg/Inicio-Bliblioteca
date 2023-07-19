using System;
using System.Collections.Generic;
using System.Linq;
using Aplication.DAL;
using Aplication.DAL.EntityFramework;
using AutoMapper;
using Aplication.Servicios.Seguridad;
using Aplication.LOG;
using Aplication.Excepciones;

namespace Aplication
{

    public class Fachada

    {
        private static readonly IMapper cMapper;
        private static readonly IHashingManager cHashingManager;

        static Fachada()
        {
            var mConfiguration = new MapperConfiguration(pConfiguration =>
            {
                pConfiguration.CreateMap<Edicion, DTOEdicion>();
                pConfiguration.CreateMap<Obra, DTOObra>();
                pConfiguration.CreateMap<Ejemplar, DTOEjemplar>().ForMember(dest => dest.codigoInventario, act => act.MapFrom(src => src.Id));
                pConfiguration.CreateMap<Ejemplar, DTOEjemplarPrestamo>().ForMember(dest => dest.codigoInventario, act => act.MapFrom(src => src.Id));
            });

            cMapper = mConfiguration.CreateMapper();

            cHashingManager = new HashingManager();
        }

        public void Inicializar()
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                if (bUoW.RepositorioUsuarios.ObtenerPorDNI(0) == null)
                {
                    var admin = new Usuario
                    {
                        Dni = 0,
                        NombreUsuario = "admin",
                        Mail = "email@cambiar.com",
                        Password = cHashingManager.Hash("admin"),
                        FechaRegistro = DateTime.Now,
                        Puntaje = 0,
                        EsAdministrador = true
                    };

                    bUoW.RepositorioUsuarios.Agregar(admin);
                }
                bUoW.Complete();
            }
        }

        public DTOUsuario ObtenerUsuario(string nombreUsuario)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuarioObtenido = bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(nombreUsuario);

                if (usuarioObtenido == null)
                {
                    return null;
                }

                return new DTOUsuario
                {
                    Nombre = usuarioObtenido.NombreUsuario,
                    Dni = usuarioObtenido.Dni,
                    Password = usuarioObtenido.Password,
                    Mail = usuarioObtenido.Mail,
                    FechaRegistro = usuarioObtenido.FechaRegistro,
                    Puntaje = usuarioObtenido.Puntaje,
                };
            }
        }

        public DTOUsuario ObtenerUsuario(int DNI)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuarioObtenido = bUoW.RepositorioUsuarios.ObtenerPorDNI(DNI);

                if (usuarioObtenido == null)
                {
                    return null;
                }

                return new DTOUsuario
                {
                    Nombre = usuarioObtenido.NombreUsuario,
                    Dni = usuarioObtenido.Dni,
                    Password = usuarioObtenido.Password,
                    Mail = usuarioObtenido.Mail,
                    FechaRegistro = usuarioObtenido.FechaRegistro,
                    Puntaje = usuarioObtenido.Puntaje,
                };
            }
        }

        public void AgregarUsuario(CrearUsuario solicitud, bool esAdmin)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                if (bUoW.RepositorioUsuarios.ObtenerPorDNI(solicitud.Dni) != null)
                {
                    throw new ExcepcionUsuarioConDniYaExiste();
                }

                if (bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(solicitud.Nombre) != null)
                {
                    throw new ExcepcionUsuarioConNombreDeUsuarioYaExiste();
                }

                if (bUoW.RepositorioUsuarios.ObtenerPorMail(solicitud.Mail) != null)
                {
                    throw new ExcepcionUsuarioConMailYaExiste();
                }

                solicitud.Password = cHashingManager.Hash(solicitud.Password);
                var usuario1 = Usuario.Crear(solicitud);

                bUoW.RepositorioUsuarios.Agregar(usuario1);
                bUoW.Complete();
            }
        }

        public void AgregarObra(DTOObra obra)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Obra obra1 = new Obra
                {
                    Titulo = obra.Titulo,
                    Lccn = obra.Lccn,
                    Descripcion = obra.Descripcion,
                    autores = obra.Autores
                };

                bUoW.RepositorioObras.Agregar(obra1);
                bUoW.Complete();
            }
        }

        public void AgregarEjemplar(DTOEjemplar ejemplar)
        {
            if (ejemplar.Edicion.Id.Length == 0)
            {
                AgregarEdicion(ejemplar.Edicion);
            }
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Edicion edicion = bUoW.RepositorioEdiciones.ObtenerPorISBN(ejemplar.Edicion.Isbn);

                if (edicion == null)
                {
                    throw new Aplication.Excepciones.ExcepcionEdicionNoExiste;
                }

                Ejemplar ejemplar1 = new Ejemplar
                {
                    Edicion = edicion,
                    FechaAlta = ejemplar.FechaAlta,
                    CodigoInventario = ejemplar.codigoInventario,
                };
                bUoW.RepositorioEjemplares.Agregar(ejemplar1);
                bUoW.Complete();
            }
        }


        public List<DTOPrestamo> PrestamosProximosAVencer()
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var sig7Dias = DateTime.Today.AddDays(7);
                var listaPrestamosProxAVencer = bUoW.RepositorioPrestamos.ObtenerProximoAVencer(sig7Dias);
                return listaPrestamosProxAVencer.Select(p => new DTOPrestamo { SolicitanteDNI = p.Solicitante.Dni, Id = p.Id, FechaPrestamo = p.FechaPrestamo, FechaVencimiento = p.FechaVencimiento }).ToList();
            }
        }

        public List<DTOPrestamo> ListarPrestamos(int dni)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var listaPrestamos = bUoW.RepositorioPrestamos.ObtenerPrestamosPorDNI(dni);
                return listaPrestamos.Select(p => new DTOPrestamo { SolicitanteDNI = p.Solicitante.Dni, Id = p.Id, FechaPrestamo = p.FechaPrestamo, FechaVencimiento = p.FechaVencimiento }).ToList();
            }
        }

        public List<DTOPrestamoConUsuarioYEjemplar> PrestamosEntreFechas(int dni, DateTime fechaInicio, DateTime fechaFin)
        {
            // 15/02/2023 xx:yy:zz -> 15/02/2023 23:59:59
            fechaFin = fechaFin.AddHours(23 - fechaFin.Hour)
                                .AddMinutes(59 - fechaFin.Minute)
                                .AddSeconds(59 - fechaFin.Second);

            // 15/02/2023 xx:yy:zz -> 15/02/2023 00:00:00
            fechaInicio = new DateTime(fechaInicio.Year, fechaInicio.Month, fechaInicio.Day);

            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var listaPrestamosEntreFechas = bUoW.RepositorioPrestamos.ObtenerPrestamosPorDNIEntreFechas(dni, fechaInicio, fechaFin);
                return listaPrestamosEntreFechas.Select(p => new DTOPrestamoConUsuarioYEjemplar { Id = p.Id, FechaPrestamo = p.FechaPrestamo, FechaVencimiento = p.FechaVencimiento, Nombre = p.Solicitante.NombreUsuario, CodigoInventario = p.Ejemplar.Id.ToString() }).ToList();
            }
        }

        public bool EsUsuarioAdmin(string nombreUsuario)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var usuario = bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(nombreUsuario);
                return usuario.EsAdministrador;
            }
        }

        public List<DTOEjemplarPrestamo> ListarEjemplaresConPrestamos(string isbn)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                List<Ejemplar> listaEjemplares = bUoW.RepositorioEjemplares.ObtenerPorISBN(isbn);
                List<DTOEjemplarPrestamo> prestamosEjemplares = new List<DTOEjemplarPrestamo>();
                foreach (var item in listaEjemplares)
                {
                    bool prestado = bUoW.RepositorioPrestamos.EjemplarEstaPrestado(item.Id);

                    var ejemplarPrestamo = cMapper.Map<DTOEjemplarPrestamo>(item);
                    ejemplarPrestamo.Prestado = prestado;
                    prestamosEjemplares.Add(ejemplarPrestamo);
                }
                return prestamosEjemplares;
            };
        }

        public List<DTOEjemplar> ListarEjemplares(string isbn)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var listaEjemplares = bUoW.RepositorioEjemplares.ObtenerPorISBN(isbn);
                var ejemplar = cMapper.Map<IList<DTOEjemplar>>(listaEjemplares);
                return ejemplar.ToList();
            };
        }

        public List<DTOEdicion> ListarEdiciones(string Lccn)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var listaEdiciones = bUoW.RepositorioEdiciones.ObtenerPorLccn(Lccn);
                var ediciones = cMapper.Map<IList<DTOEdicion>>(listaEdiciones);
                return ediciones.ToList();
            };
        }

        public DTOEdicion BuscarEdicion(string ISBN)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Edicion encontrado = bUoW.RepositorioEdiciones.ObtenerPorISBN(ISBN);

                if (encontrado == null)
                {
                    return null;
                }

                var ediciones = cMapper.Map<DTOEdicion>(encontrado);
                return ediciones;
            };
        }

        public void AgregarEdicion(DTOEdicion edicion)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Obra obra = null;

                try
                {
                    obra = bUoW.RepositorioObras.ObtenerPorLccn(edicion.Obra.Lccn);
                }
                catch (Exception) { }

                if (obra == null)
                {
                    AgregarObra(edicion.Obra);
                    obra = bUoW.RepositorioObras.ObtenerPorLccn(edicion.Obra.Lccn);
                }

                Edicion edition = new Edicion
                {
                    Isbn = edicion.Isbn,
                    AñoEdicion = edicion.AnioEdicion,
                    NumeroPaginas = edicion.NumeroPaginas,
                    Portada = edicion.Portada,
                    FechaPublicacion = edicion.FechaPublicacion,
                    Obra = obra,
                };
                bUoW.RepositorioEdiciones.Agregar(edition);
                bUoW.Complete();
            }
        }

        public bool ExisteEdicion(string Isbn)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Edicion edicion = bUoW.RepositorioEdiciones.ObtenerPorISBN(Isbn);
                return edicion != null;
            }
        }
        public void BajaUsuario(int dni)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(dni);
                bUoW.RepositorioUsuarios.Eliminar(usuario);
                bUoW.Complete();
            }

        }
        public bool ExisteUsuario(int Dni)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(Dni);
                return usuario != null;
            }
        }
        public void ModificarDatosUsuario(int dni, ActualizarUsuario solicitud)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuario1 = bUoW.RepositorioUsuarios.ObtenerPorDNI(dni);

                if (usuario1 == null)
                {
                    throw new Exception("No existe el usuario");
                }

                if (solicitud.Nombre != null
                    && solicitud.Nombre != usuario1.NombreUsuario
                    && bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(solicitud.Nombre) != null)
                {
                    throw new ExcepcionUsuarioConNombreDeUsuarioYaExiste();
                }

                if (solicitud.Mail != null
                    && solicitud.Mail != usuario1.Mail
                    && bUoW.RepositorioUsuarios.ObtenerPorMail(solicitud.Mail) != null)
                {
                    throw new ExcepcionUsuarioConMailYaExiste();
                }

                if (solicitud.Password != null)
                {
                    // hashear contraseña
                    solicitud.Password = cHashingManager.Hash(solicitud.Password);
                }

                usuario1.Actualizar(solicitud);

                bUoW.Complete();
            }
        }
        public bool LoguearUsuario(string nombreUsuario, string password)
        {
            bool contraCorrecta = false;

            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario us1 = bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(nombreUsuario);

                if (us1 == null)
                {
                    return false;
                }

                if (!cHashingManager.IsHashSupported(us1.Password))
                {
                    LogManager.GetLogger().Warn("Una contraseña almacenada no soporta el hasher!");
                    return false;
                }

                contraCorrecta = cHashingManager.Verify(password, us1.Password);

                bUoW.Complete();
            }

            return contraCorrecta;
        }

        public void PrestarEjemplar(int dni, string codigoInventario)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                if (!Int32.TryParse(codigoInventario, out int codigoEjemplar))
                {
                    throw new ExcepcionCodigoInventarioInvalido();
                }

                if (this.EstaPrestadoEjemplar(codigoInventario))
                {
                    throw new ExcepcionEjemplarYaPrestado();
                }

                Ejemplar ejemplar = bUoW.RepositorioEjemplares.Obtener(codigoEjemplar);

                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(dni);

                var prestamo = Prestamo.Crear(DateTime.Now, usuario, ejemplar);

                bUoW.RepositorioPrestamos.Agregar(prestamo);

                bUoW.Complete();
            }
        }

        public void DevolverEjemplar(string codigoEjemplar, bool buenEstado)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                if (!Int32.TryParse(codigoEjemplar, out int codigoEjemplarInt))
                {
                    throw new ExcepcionCodigoInventarioInvalido();
                }

                Prestamo prestamo = bUoW.RepositorioPrestamos.ObtenerPorCodigoEjemplar(codigoEjemplarInt)
                                            .Where(u => u.FechaDevolucion == null).FirstOrDefault();

                if (prestamo == null)
                {
                    throw new ExcepcionEjemplarNoEstaPrestado();
                }

                Usuario usuario = prestamo.Solicitante;

                prestamo.FechaDevolucion = DateTime.Now;
                prestamo.DevolverEjemplar(buenEstado);

                bUoW.Complete();
            }
        }
        public void BajaEjemplar(string codigoInventario)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                if (!Int32.TryParse(codigoInventario, out int codigoEjemplar))
                {
                    throw new ExcepcionCodigoInventarioInvalido();
                }

                Ejemplar ejemplar = bUoW.RepositorioEjemplares.Obtener(codigoEjemplar);

                ejemplar.FechaBaja = DateTime.Now;
                bUoW.Complete();
            }
        }

        public int CantidadDiaMaximoHabilesDeUsuario(int dni)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(dni);
                return usuario.MaximoDiasHabilesPrestamos();
            }
        }

        public bool ExisteEjemplar(string codigoInventario)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                if (!Int32.TryParse(codigoInventario, out int codigoEjemplar))
                {
                    return false;
                }

                Ejemplar ejemplar = bUoW.RepositorioEjemplares.Obtener(codigoEjemplar);
                return ejemplar != null;
            }
        }

        public bool EstaPrestadoEjemplar(string codigoInventario)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                if (!Int32.TryParse(codigoInventario, out int codigoInvInt))
                {
                    throw new ExcepcionCodigoInventarioInvalido();
                }

                return bUoW.RepositorioPrestamos.EjemplarEstaPrestado(codigoInvInt);
            }
        }

    }
}