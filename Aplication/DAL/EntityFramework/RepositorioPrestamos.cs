using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.DAL.EntityFramework
{
    public class RepositorioPrestamos : Repository<Prestamo, BibliotecaDbContext>, IRepositorioPrestamos
    {
        public RepositorioPrestamos(BibliotecaDbContext pDbContext) : base(pDbContext)
        {

        }

        public List<Prestamo> ObtenerPrestamosPorDNI(int dni)
        {
            return iDbSet
                    .Where(u => u.Solicitante.Dni == dni).ToList();
        }

        public List<Prestamo> ObtenerProximoAVencer(DateTime limite)
        {
            return iDbSet
                    .Where(u => (u.FechaVencimiento <= limite && u.FechaDevolucion == null))
                    .ToList();
        }

        public List<Prestamo> ObtenerPrestamosPorDNIEntreFechas(int dni, DateTime start, DateTime end)
        {
            return iDbSet
                    .Where(u => (u.Solicitante.Dni == dni && u.FechaPrestamo >= start && u.FechaPrestamo <= end))
                    .ToList();
        }

        public bool EjemplarEstaPrestado(int idEjemplar)
        {
            return iDbSet
                    .Where(u => (u.Ejemplar.Id == idEjemplar && u.FechaDevolucion == null))
                    .Any();
        }
    }
}