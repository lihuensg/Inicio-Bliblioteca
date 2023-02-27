using System;
using System.Collections.Generic;
using Aplication.LOG; 

namespace Aplication
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.initialize();
            /*var filtros = new Dictionary<string, string>() { { "Nombre", "ROWLING" } };
            var autores = ServiceAutoresOpenLibrary.Buscar(filtros);
            LogManager.GetLogger().Info("Tamaños de lista: {0}", autores.Count);
            var filtrosEdiciones = new Dictionary<string, string>() { { "ISBN", "9780140328721" } };
            var edicion = ServiceEdicionesOpenLibrary.Buscar(filtrosEdiciones);
            LogManager.GetLogger().Info("Encontrado? : {0}", (edic
            ion != null ? "Sí" : "No"));

            var filtrosObras = new Dictionary<string, string>() { { "Autor", "Brandon Sanderson" }, { "Titulo", "Mistborn" } };
            var obras = ServicesObrasOpenLibrary.Buscar(filtrosObras);
            LogManager.GetLogger().Info("Tamaños de lista: {0}", obras.Count); */
            

            Fachada fachada = new Fachada();
            DTOUsuario dTOUsuario = new DTOUsuario
            {
                Nombre = "Franchescoli",
                Dni = 42477105,
                Password = "Patita123", 
                Mail = "cobibraint@gmail.com",
                FechaRegistro = DateTime.Now , 
                Puntaje = 140, 


            };
            CrearUsuario dTOUsuario1 = new CrearUsuario
            {
                Nombre = "Enzo",
                Dni = 425,
                Password = "Enzo123", 
                Mail = "Enzo@gmail.com",
            


            };
            fachada.AgregarUsuario(dTOUsuario1, true); 
            if(fachada.LoguearUsuario(dTOUsuario1.Nombre , dTOUsuario1.Password))
            {
                LogManager.GetLogger().Info("Logueado correctamente"); 
            }
            else 
            {
               LogManager.GetLogger().Info("Usuario y/o contraseña incorrectos");  
            }
            LogManager.shutdown(); 


        }

    }
}
