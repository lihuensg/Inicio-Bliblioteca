using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Aplication.SERVICE.Http;
using Aplication.LOG;

namespace Aplication
{
    public class ServicesObrasOpenLibrary:IServicesObras
    {
        private readonly static ServicesObrasOpenLibrary _instance = new ServicesObrasOpenLibrary();

        private ServicesObrasOpenLibrary()
        {
        }

        public static ServicesObrasOpenLibrary Instance
        {
            get
            {
                return _instance;
            }
        }
        public List<DTOObra> Buscar(Dictionary<string, string> pFiltros)
        {
            if (pFiltros.Count == 0)
            {
                throw new Exception("Se nececita filtrar por Id o Nombre");
            }
            // Url de ejemplo
            string mUrl = "";

            mUrl = "https://openlibrary.org/search.json?limit=5&";

            if (pFiltros.ContainsKey("Autor") && pFiltros["Autor"].Length > 0)
            {
                mUrl += "author=" + HttpUtility.HtmlEncode(pFiltros["Autor"]) + "&";
            }
            if (pFiltros.ContainsKey("Titulo") && pFiltros["Titulo"].Length > 0)
            {
                mUrl += "title=" + HttpUtility.HtmlEncode(pFiltros["Titulo"]);
            }

            List<DTOObra> obras = new List<DTOObra>();
            try
            {
                dynamic mResponseJSON = HttpJsonRequest.Obtener(mUrl);

                LogManager.GetLogger().Error("numFound: {0}", mResponseJSON.numFound);

                int contador = 0;
                // Se iteran cada uno de los resultados
                foreach (var bResponseItem in mResponseJSON.docs)
                {
                    if (contador > 5)
                    {
                        break;
                    }

                    DTOObra obra = new DTOObra();
                    var listaAutores = new List<string>();

                    foreach (var autorkey in bResponseItem.author_key)
                    {
                        // como lo buscamos por el id que nos da openlibrary sabemos que existe
                        var autores = ServiceAutoresOpenLibrary.Instance.Buscar(new Dictionary<string, string>() { { "Id", autorkey.Value } });
                        listaAutores.Add(autores[0].Nombre);
                    }
                     
                    foreach (var author in listaAutores)
                    {
                        obra.Autores += author + ",";
                    }
                    
                    obra.Titulo = HttpUtility.HtmlDecode(bResponseItem.title.ToString());
                    obra.Generos = new List<string>();
                    if (bResponseItem.ContainsKey("subject"))
                    {
                        foreach (var genero in bResponseItem.subject)
                        {
                            obra.Generos.Add(genero.Value);
                        }
                    }

                    obra.Ediciones = new List<DTOEdicion>();
                    if (bResponseItem.ContainsKey("edition_key"))
                    {
                        foreach (var edicionkey in bResponseItem.edition_key)
                        {
                            // TODO: Ediciones -> Buscar devuelve un DTOEdicion, no una lista.
                            DTOEdicion edicion = ServiceEdicionesOpenLibrary.Instance.Buscar(new Dictionary<string, string>() { { "Id", edicionkey.Value } });
                            if (edicion != null)
                            {
                                obra.Ediciones.Add(edicion);
                            }
                        }
                    }

                    obras.Add(obra);
                    contador++;
                }
            }
            catch (ExcepcionConsultaWeb ex)
            {
                LogManager.GetLogger().Error(ex, "No se puede realizar la consulta en el servidor");
            }
            catch (ExcepcionRespuestaInvalida ex1)
            {
                LogManager.GetLogger().Error("Error {0}", ex1.Message);
            }
            return obras;

        }
    }
}
