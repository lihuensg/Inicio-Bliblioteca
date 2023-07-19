using System;

namespace Aplication.Servicios.LibrosRemotos.OpenLibrary
{
    public class OpenLibraryServiceFactory : ILibraryServiceFactory
    {
        public IServicesEdicion ObtenerServiceEdicion()
        {
            return new ServiceEdicionesOpenLibrary();
        }

        public IServicesObras ObtenerServiceObra()
        {
            return new ServicesObrasOpenLibrary();
        }

        public IServicesAutores ObtenerServiceAutores()
        {
            return new ServiceAutoresOpenLibrary();
        }
    }
}