using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class AdminPrestamos
    {
        public AdminPrestamos()
        {

        }

        public int CantDiasExtensionDePrestamo(Usuario pUsuario)
        {
            if (pUsuario.Puntaje < 0)
            {
                return 0;
            }
            else
            {
                return (int)Math.Floor((double)pUsuario.Puntaje / Constantes.PuntajeDeExtensionPorDiaDePrestamo);
            } 
           
        }

        public Prestamo CrearPrestamo(Usuario pUsuario, Ejemplar pEjemplar, int IdPrestamo)
        {
            var fechaVencimiento = DateTime.Now.AddDays(Constantes.DiasBaseDePrestamo + CantDiasExtensionDePrestamo(pUsuario));
            Prestamo prestamo1 = new Prestamo(IdPrestamo, DateTime.Now, fechaVencimiento, pEjemplar, pUsuario);
            return prestamo1;
        }

    }
}