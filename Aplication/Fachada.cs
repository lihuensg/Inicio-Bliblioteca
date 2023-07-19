using System;
using System.Collections.Generic;
using System.Linq;
using Aplication.DAL;
using Aplication.DAL.EntityFramework;
using AutoMapper;
using Aplication.Servicios.Seguridad;
using Aplication.LOG;
using Aplication.Excepciones;
using Aplication.Contratos.Ejemplar;
using Aplication.Excepciones.Ediciones;
using Aplication.Excepciones.Usuarios;
using Aplication.Excepciones.Ejemplares;
using Aplication.Excepciones.Obras;

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
            });

            cMapper = mConfiguration.CreateMapper();

            cHashingManager = new HashingManager();
        }

        /// <summary>
        /// Inicializa la base de datos con un usuario administrador
        /// </summary>
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

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <returns>Usuario o null si no existe.</returns>
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

        /// <summary>
        /// Obtiene un usuario por su DNI.
        /// </summary>
        /// <param name="DNI">DNI del usuario.</param>
        /// <returns>Usuario o null si no existe.</returns>
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

        /// <summary>
        /// Agrega un usuario.
        /// </summary>
        /// <param name="solicitud">Solicitud con los datos del usuario a agregar.</param>
        /// <param name="esAdmin">Indica si el usuario a agregar es administrador.</param>
        /// <exception cref="ExcepcionUsuarioConDniYaExiste">Si ya existe un usuario con el DNI indicado.</exception>
        /// <exception cref="ExcepcionUsuarioConNombreDeUsuarioYaExiste">Si ya existe un usuario con el nombre de usuario indicado.</exception>
        /// <exception cref="ExcepcionUsuarioConMailYaExiste">Si ya existe un usuario con el mail indicado.</exception>
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

        /// <summary>
        /// Agrega una obra.
        /// </summary>
        /// <param name="nuevaObra">Datos de la obra a agregar.</param>
        /// <exception cref="ExcepcionObraYaExiste">Si ya existe una obra con el LCCN indicado.</exception>
        public void AgregarObra(DTOObra nuevaObra)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                if (bUoW.RepositorioObras.ObtenerPorLccn(nuevaObra.Lccn) != null)
                {
                    throw new ExcepcionObraYaExiste();
                }

                Obra obra = new Obra
                {
                    Titulo = nuevaObra.Titulo,
                    Lccn = nuevaObra.Lccn,
                    Descripcion = nuevaObra.Descripcion,
                    autores = nuevaObra.Autores
                };

                bUoW.RepositorioObras.Agregar(obra);
                bUoW.Complete();
            }
        }

        /// <summary>
        /// Agrega un ejemplar.
        /// </summary>
        /// <param name="ejemplar">Datos del ejemplar a agregar.</param>
        /// <exception cref="ExcepcionEdicionNoExiste">Si no existe una edición con el ISBN indicado.</exception>
        public void AgregarEjemplar(AgregarEjemplar ejemplar)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Edicion edicion = bUoW.RepositorioEdiciones.ObtenerPorISBN(ejemplar.ISBNEdicion);

                if (edicion == null)
                {
                    throw new ExcepcionEdicionNoExiste();
                }

                Ejemplar ejemplar1 = new Ejemplar
                {
                    Edicion = edicion,
                    FechaAlta = DateTime.Now, // TODO: Usar un TimeProvider si es necesario para los tests.
                    CodigoInventario = "2", // TODO: el codigo ingresado aqui no es relevante, se mapea desde el id
                                            // del ejemplar en la base de datos. Quitar el required.
                };

                bUoW.RepositorioEjemplares.Agregar(ejemplar1);
                bUoW.Complete();
            }
        }

        /// <summary>
        /// Obtiene una lista de prestamos proximos a vencer.
        /// </summary>
        /// <returns>Lista de prestamos proximos a vencer.</returns>
        public List<DTOPrestamo> PrestamosProximosAVencer()
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var sig7Dias = DateTime.Today.AddDays(7);
                var listaPrestamosProxAVencer = bUoW.RepositorioPrestamos.ObtenerProximoAVencer(sig7Dias);
                return listaPrestamosProxAVencer.Select(p => new DTOPrestamo { SolicitanteDNI = p.Solicitante.Dni, Id = p.Id, FechaPrestamo = p.FechaPrestamo, FechaVencimiento = p.FechaVencimiento }).ToList();
            }
        }

        /// <summary>
        /// Obtiene una lista de prestamos entre dos fechas para un usuario.
        /// </summary>
        /// <param name="dni">DNI del usuario.</param>
        /// <param name="fechaInicio">Fecha de inicio.</param>
        /// <param name="fechaFin">Fecha de fin.</param>
        /// <returns>Lista de prestamos entre dos fechas para un usuario.</returns>
        public List<DTOPrestamoConUsuarioYEjemplar> PrestamosEntreFechas(int dni, DateTime fechaInicio, DateTime fechaFin)
        {
            // Setea la fecha fin a las 23:59:59
            fechaFin = fechaFin.AddHours(23 - fechaFin.Hour)
                                .AddMinutes(59 - fechaFin.Minute)
                                .AddSeconds(59 - fechaFin.Second);

            // Setea la fecha inicio a las 00:00:00
            fechaInicio = new DateTime(fechaInicio.Year, fechaInicio.Month, fechaInicio.Day);

            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var listaPrestamosEntreFechas = bUoW.RepositorioPrestamos.ObtenerPrestamosPorDNIEntreFechas(dni, fechaInicio, fechaFin);
                return listaPrestamosEntreFechas.Select(p => new DTOPrestamoConUsuarioYEjemplar { Id = p.Id, FechaPrestamo = p.FechaPrestamo, FechaVencimiento = p.FechaVencimiento, Nombre = p.Solicitante.NombreUsuario, CodigoInventario = p.Ejemplar.Id.ToString() }).ToList();
            }
        }

        /// <summary>
        /// Verifica si un usuario es administrador.
        /// </summary>
        /// <remark>Se utiliza para verificar si un usuario puede realizar ciertas acciones.</remark>
        /// <param name="nombreUsuario">Nombre de usuario del usuario a verificar.</param>
        /// <returns>true si el usuario es administrador</returns>
        public bool EsUsuarioAdmin(string nombreUsuario)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var usuario = bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(nombreUsuario);
                return usuario.EsAdministrador;
            }
        }

        /// <summary>
        /// Obtiene una lista de ejemplares de una edicion.
        /// </summary>
        /// <param name="isbn">ISBN de la edicion.</param>
        /// <returns>Lista de ejemplares con datos sobre si esta prestado.</returns>
        public List<DTOEjemplar> ListarEjemplares(string isbn)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                List<Ejemplar> listaEjemplares = bUoW.RepositorioEjemplares.ObtenerPorISBN(isbn);
                List<DTOEjemplar> prestamosEjemplares = new List<DTOEjemplar>();
                foreach (var item in listaEjemplares)
                {
                    bool estaPrestado = bUoW.RepositorioPrestamos.EjemplarEstaPrestado(item.Id);

                    var ejemplarPrestamo = cMapper.Map<DTOEjemplar>(item);
                    ejemplarPrestamo.Prestado = estaPrestado;
                    prestamosEjemplares.Add(ejemplarPrestamo);
                }
                return prestamosEjemplares;
            };
        }

        /// <summary>
        /// Obtiene una lista de ediciones para una obra.
        /// </summary>
        /// <param name="Lccn">LCCN de la obra.</param>
        /// <returns>Lista de ediciones.</returns>
        public List<DTOEdicion> ListarEdiciones(string Lccn)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                var listaEdiciones = bUoW.RepositorioEdiciones.ObtenerPorLccn(Lccn);
                var ediciones = cMapper.Map<IList<DTOEdicion>>(listaEdiciones);
                return ediciones.ToList();
            };
        }

        /// <summary>
        /// Busca una edicion por ISBN.
        /// </summary>
        /// <param name="ISBN">ISBN de la edicion.</param>
        /// <returns>Edicion o null si no se encuentra.</returns>
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

        /// <summary>
        /// Agrega una edicion.
        /// </summary>
        /// <param name="edicion">Edicion a agregar.</param>
        public void AgregarEdicion(DTOEdicion edicion)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Obra obra = bUoW.RepositorioObras.ObtenerPorLccn(edicion.Obra.Lccn);

                if (obra == null)
                {
                    AgregarObra(edicion.Obra); // no puede lanzar excepcion

                    obra = bUoW.RepositorioObras.ObtenerPorLccn(edicion.Obra.Lccn);
                }

                if (bUoW.RepositorioEdiciones.ObtenerPorISBN(edicion.Isbn) != null)
                {
                    throw new ExcepcionEdicionYaExiste();
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

        /// <summary>
        /// Da de baja un usuario.
        /// </summary>
        /// <param name="dni">DNI del usuario a dar de baja.</param>
        public void BajaUsuario(int dni)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(dni);
                bUoW.RepositorioUsuarios.Eliminar(usuario);
                bUoW.Complete();
            }
        }

        /// <summary>
        /// Verifica si existe un usuario.
        /// </summary>
        /// <param name="Dni">DNI del usuario a verificar.</param>
        /// <returns>true si el usuario existe.</returns>
        public bool ExisteUsuario(int Dni)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(Dni);
                return usuario != null;
            }
        }

        /// <summary>
        /// Modifica los datos de un usuario.
        /// </summary>
        /// <param name="dni">DNI del usuario a modificar.</param>
        /// <param name="solicitud">Datos a modificar. Dejar en null los campos que no se quieran modificar.</param>
        /// <exception cref="ExcepcionUsuarioNoExiste">Si el usuario no existe.</exception>
        /// <exception cref="ExcepcionUsuarioConNombreDeUsuarioYaExiste">Si el nombre de usuario ya existe.</exception>
        /// <exception cref="ExcepcionUsuarioConMailYaExiste">Si el mail ya existe.</exception>
        public void ModificarDatosUsuario(int dni, ActualizarUsuario solicitud)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorDNI(dni);

                if (usuario == null)
                {
                    throw new ExcepcionUsuarioNoExiste();
                }

                if (solicitud.Nombre != null
                    && solicitud.Nombre != usuario.NombreUsuario
                    && bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(solicitud.Nombre) != null)
                {
                    throw new ExcepcionUsuarioConNombreDeUsuarioYaExiste();
                }

                if (solicitud.Mail != null
                    && solicitud.Mail != usuario.Mail
                    && bUoW.RepositorioUsuarios.ObtenerPorMail(solicitud.Mail) != null)
                {
                    throw new ExcepcionUsuarioConMailYaExiste();
                }

                if (solicitud.Password != null)
                {
                    // hashear contraseña
                    solicitud.Password = cHashingManager.Hash(solicitud.Password);
                }

                usuario.Actualizar(solicitud);

                bUoW.Complete();
            }
        }

        /// <summary>
        /// Inicia sesion de un usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario.</param>
        /// <param name="password">Contraseña.</param>
        /// <returns>true si el usuario existe y la contraseña es correcta.</returns>
        public bool LoguearUsuario(string nombreUsuario, string password)
        {
            bool contraCorrecta = false;

            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                Usuario usuario = bUoW.RepositorioUsuarios.ObtenerPorNombreDeUsuario(nombreUsuario);

                if (usuario == null)
                {
                    return false;
                }

                if (!cHashingManager.IsHashSupported(usuario.Password))
                {
                    LogManager.GetLogger().Warn("Una contraseña almacenada no soporta el hasher!");
                    return false;
                }

                contraCorrecta = cHashingManager.Verify(password, usuario.Password);

                bUoW.Complete();
            }

            return contraCorrecta;
        }

        /// <summary>
        /// Presta un ejemplar.
        /// </summary>
        /// <param name="dni">DNI del usuario que pide el ejemplar.</param>
        /// <param name="codigoInventario">Código de inventario del ejemplar.</param>
        /// <returns>Fecha de vencimiento del préstamo.</returns>
        /// <exception cref="ExcepcionCodigoInventarioInvalido">Si el código de inventario no es válido.</exception>
        /// <exception cref="ExcepcionEjemplarYaPrestado">Si el ejemplar ya está prestado.</exception>
        public DateTime PrestarEjemplar(int dni, string codigoInventario)
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

                return prestamo.FechaVencimiento;
            }
        }

        /// <summary>
        /// Devuelve un ejemplar con estado.
        /// </summary>
        /// <param name="codigoEjemplar">Código de inventario del ejemplar.</param>
        /// <param name="buenEstado">true si el ejemplar está en buen estado.</param>
        /// <exception cref="ExcepcionCodigoInventarioInvalido">Si el código de inventario no es válido.</exception>
        /// <exception cref="ExcepcionEjemplarNoEstaPrestado">Si el ejemplar no está prestado.</exception>
        public void DevolverEjemplar(string codigoEjemplar, bool buenEstado)
        {
            using (IUnitOfWork bUoW = new UnitOfWork(new BibliotecaDbContext()))
            {
                if (!Int32.TryParse(codigoEjemplar, out int codigoEjemplarInt))
                {
                    throw new ExcepcionCodigoInventarioInvalido();
                }

                Prestamo prestamo = bUoW.RepositorioPrestamos
                                            .ObtenerPorCodigoEjemplar(codigoEjemplarInt)
                                            .Where(u => u.FechaDevolucion == null)
                                            .FirstOrDefault();

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

        /// <summary>
        /// Da de baja un ejemplar.
        /// </summary>
        /// <param name="codigoInventario">Código de inventario del ejemplar.</param>
        /// <exception cref="ExcepcionCodigoInventarioInvalido">Si el código de inventario no es válido.</exception>
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

        /// <summary>
        /// Verifica si existe un ejemplar.
        /// </summary>
        /// <param name="codigoInventario">Código de inventario del ejemplar.</param>
        /// <returns>true si existe.</returns>
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

        /// <summary>
        /// Verifica si un ejemplar está prestado.
        /// </summary>
        /// <param name="codigoInventario">Código de inventario del ejemplar.</param>
        /// <returns>true si está prestado.</returns>
        /// <exception cref="ExcepcionCodigoInventarioInvalido">Si el código de inventario no es válido.</exception>
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