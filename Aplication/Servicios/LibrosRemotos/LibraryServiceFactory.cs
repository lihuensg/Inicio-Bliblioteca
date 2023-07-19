using System;

namespace Aplication.Servicios.LibrosRemotos
{
    public interface ILibraryServiceFactory
    {
        IServicesEdicion ObtenerServiceEdicion();
        IServicesObras ObtenerServiceObra();
        IServicesAutores ObtenerServiceAutores();
    }

    /// <summary>
    /// Uso del patrón Abstract Factory para proveer los servicios de edición, autores y obra.
    ///
    /// Lo principal era no complejizar el proyecto con Inyección de Dependencias.
    /// Si bien se podría mejorar respecto al principio de segregación de interfaces, 
    /// creemos que esta separación es suficiente.
    /// </summary>
    public class LibraryServiceFactory : ILibraryServiceFactory
    {
        static ILibraryServiceFactory proveedor;

        public static void SetearProveedor(ILibraryServiceFactory pProveedor)
        {
            proveedor = pProveedor;
        }

        public IServicesEdicion ObtenerServiceEdicion()
        {
            return proveedor.ObtenerServiceEdicion();
        }

        public IServicesObras ObtenerServiceObra()
        {
            return proveedor.ObtenerServiceObra();
        }

        public IServicesAutores ObtenerServiceAutores()
        {
            return proveedor.ObtenerServiceAutores();
        }
    }
}