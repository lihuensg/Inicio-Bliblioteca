using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Aplication
{
    public interface IRepositorioPrestamos : IRepositorio<Prestamo>
    {
        /// <summary>
        /// Obtiene prestamos por el dni del usuario que lo solicito
        /// </summary>
        /// <param name="id">id del prestamo</param>
        /// <returns>Lista de Prestamos</returns>
        List<Prestamo> ObtenerPrestamosPorDNI(int dni);

        /// <summary>
        /// Obtiene prestamos por el dni del usuario que lo solicito, entre dos fechas.
        /// </summary>
        /// <param name="dni">dni del autor del prestamo</param>
        /// <param name="start">fecha de inicio</param>
        /// <param name="end">fecha de fin</param>
        /// <returns>Lista de Prestamos</returns>
        List<Prestamo> ObtenerPrestamosPorDNIEntreFechas(int dni, DateTime start, DateTime end);

        /// <summary>
        /// Obtiene prestamos proximos a vencer.
        /// </summary>
        /// <param name="limite">dias a considerar como proximos a vencer</param>
        /// <returns>Lista de Prestamos</returns>
        List<Prestamo> ObtenerProximoAVencer(DateTime limite);

        /// <summary>
        /// Obtiene prestamos por el codigo del ejemplar prestado.
        /// </summary>
        /// <param name="codigoEjemplar">codigo del ejemplar</param>
        /// <returns>Lista de Prestamos</returns>
        List<Prestamo> ObtenerPorCodigoEjemplar(int codigoEjemplar);

        /// <summary>
        /// Verifica si un ejemplar esta prestado.
        /// </summary>
        /// <param name="idEjemplar">id del ejemplar, el codigo inventario.</param>
        /// <returns>verdadero si esta prestado</returns>
        bool EjemplarEstaPrestado(int idEjemplar);

    }
}