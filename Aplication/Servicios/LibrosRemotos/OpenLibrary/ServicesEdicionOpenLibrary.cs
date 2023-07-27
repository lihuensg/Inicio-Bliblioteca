using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Globalization;
using Aplication.SERVICE.Http;
using Aplication.LOG;
using System.Net.Http;
using System.Net.Http.Json;
using System.Json;
using Newtonsoft.Json.Linq;
using Aplication.Utils;

namespace Aplication.Servicios.LibrosRemotos.OpenLibrary
{
    public class ServiceEdicionesOpenLibrary : IServiciosEdicion
    {
        private readonly HttpClient mCliente;

        public ServiceEdicionesOpenLibrary(IHttpClientFactory pClienteFactory)
        {
            mCliente = pClienteFactory.CreateClient("OpenLibrary");
        }

        public async Task<DTOEdicion> BuscarPorISBNAsync(string pIsbn)
        {
            try
            {
                var respuesta = await mCliente.GetAsync($"api/books?bibkeys=ISBN:{pIsbn}&jscmd=data&format=json");

                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new ExcepcionConsultaWeb("Error al obtener la respuesta");
                }

                if (respuesta.Content.Headers.ContentType.MediaType != "application/json")
                {
                    throw new ExcepcionRespuestaInvalida("Respuesta invalida");
                }

                var bodyJson = await respuesta.Content.ReadAsStringAsync();
                var cuerpo = JObject.Parse(bodyJson);

                if (cuerpo == null || cuerpo.Count == 0)
                {
                    return null;
                }

                DTOEdicion edicion = ConvertirEdicionDesdeJsonData(pIsbn, cuerpo);
                /*
                                DTOEdicion edicion = new DTOEdicion();

                                //https://openlibrary.org/api/books?bibkeys=ISBN:978-0-9767736-6-5&jscmd=data&format=json
                                var llave = $"ISBN:{pIsbn}";
                                if (mResponseJson.ContainsKey(llave))
                                {
                                    mResponseJson = (JObject)mResponseJson[llave];

                                    if (mResponseJson == null)
                                    {
                                        return null;
                                    }
                                }

                                edicion.Isbn = pIsbn;

                                if (mResponseJson.ContainsKey("number_of_pages"))
                                {
                                    edicion.NumeroPaginas = (int)mResponseJson["number_of_pages"];
                                }

                                string portada = null;
                                if (mResponseJson.ContainsKey("cover"))
                                {
                                    var cover = (JObject)mResponseJson["cover"];
                                    if (cover.ContainsKey("medium"))
                                    {
                                        portada = (string)cover["medium"];
                                    }
                                    else if (cover.ContainsKey("large"))
                                    {
                                        portada = (string)cover["large"];
                                    }
                                    else if (cover.ContainsKey("small"))
                                    {
                                        portada = (string)cover["small"];
                                    }
                                }

                                edicion.Portada = portada != null ? portada : $"https://covers.openlibrary.org/b/isbn/{pIsbn}-M.jpg";

                                if (mResponseJson.ContainsKey("publish_date"))
                                {
                                    string fechaString = (string)mResponseJson["publish_date"];
                                    try
                                    {
                                        edicion.FechaPublicacion = PasarFecha(fechaString, new CultureInfo("en-US"));

                                        edicion.AnioEdicion = edicion.FechaPublicacion.Year;
                                    }
                                    catch (FormatException ex)
                                    {
                                        // Error fecha invalida
                                        LogManager.GetLogger().Error(ex, "Error: Fecha invalida '{0}'. {1}", fechaString, ex.Message);
                                    }
                                }

                                // seteamos los datos de la obra
                                edicion.Obra = new DTOObra();
                                edicion.Obra.Generos = new List<string>();
                                if (mResponseJson.ContainsKey("subjects"))
                                {
                                    foreach (var genero in mResponseJson["subjects"])
                                    {
                                        if (genero.Type == JTokenType.String)
                                        {
                                            edicion.Obra.Generos.Add((string)genero);
                                        }
                                        else if (genero.Type == JTokenType.Object && genero["name"] != null)
                                        {
                                            edicion.Obra.Generos.Add((string)genero["name"]);
                                        }
                                    }
                                }

                                if (mResponseJson.ContainsKey("authors")
                                    && mResponseJson["authors"].Type == JTokenType.Array
                                    && mResponseJson["authors"].Count() > 0)
                                {
                                    var autores = mResponseJson["authors"];
                                    if (autores[0].Type == JTokenType.String)
                                    {
                                        edicion.Obra.Autores = string.Join(", ", autores.Select(a => (string)a["name"]));
                                    }
                                }

                                edicion.Obra.Titulo = mResponseJson.ContainsKey("title") ? (string)mResponseJson["title"] : null;
                                edicion.Obra.Descripcion = mResponseJson.ContainsKey("subtitle") ? (string)mResponseJson["subtitle"] : null;
                                //edicion.Obra.Lccn = lccn;

                                edicion.Obra.Ediciones = new List<DTOEdicion>();
                */
                return edicion;
            }
            catch (ExcepcionConsultaWeb e)
            {
                LogManager.GetLogger().Error(e, "No se puede realizar la consulta en el servidor");
            }
            catch (ExcepcionRespuestaInvalida e)
            {
                LogManager.GetLogger().Error(e, "Respuesta invalida");
            }
            catch (Exception e)
            {
                LogManager.GetLogger().Error(e, "Error desconocido");
            }

            return null;
        }

        private DTOEdicion ConvertirEdicionDesdeJsonData(string isbn, JObject cuerpo)
        {
            if (cuerpo == null)
            {
                return null;
            }

            // implementacion para convertir el json especificado aqui en un DTOEdicion
            // https://openlibrary.org/dev/docs/api/books#:~:text=books/OL23377687M/adventures_of_Tom_Sawyer%22%0A%20%20%20%20%7D%0A%7D-,jscmd%3Ddata,-When%20the%20jscmd
            DTOEdicion edicion = new DTOEdicion();

            cuerpo = (JObject)cuerpo[$"ISBN:{isbn}"];

            edicion.Titulo = cuerpo.GetOptional<string>("title", "");
            edicion.Descripcion = cuerpo.GetOptional<string>("subtitle", "");

            edicion.Isbn = isbn;
            edicion.NumeroPaginas = cuerpo.GetOptional<int>("number_of_pages", 0);

            if (cuerpo.ContainsKey("authors"))
            {
                edicion.Autores = string.Join(", ", cuerpo["authors"].Select(a => (string)a["name"]));
            }

            if (cuerpo.ContainsKey("publish_date"))
            {
                string fechaString = (string)cuerpo["publish_date"];
                try
                {
                    DateTime fechaPublicacion = PasarFecha(fechaString, new CultureInfo("en-US"));

                    edicion.Publicacion = fechaPublicacion.ToString("dd/MM/yyyy");

                    edicion.AñoEdicion = fechaPublicacion.Year;
                }
                catch (FormatException ex)
                {
                    // Error fecha invalida
                    LogManager.GetLogger().Error(ex, "Error: Fecha invalida '{0}'. {1}", fechaString, ex.Message);
                }
            }

            if (cuerpo.ContainsKey("publishers"))
            {
                string publicadores = string.Join(", ", cuerpo["publishers"].Select(a => (string)a["name"]));
                edicion.Publicacion = publicadores + ";" + edicion.Publicacion;
            }

            edicion.Portada = $"https://covers.openlibrary.org/b/isbn/{isbn}-M.jpg";

            return edicion;
        }

        private static DateTime PasarFecha(string fecha, CultureInfo cultureInfo)
        {
            DateTime date;
            string procesada = fecha;

            if (cultureInfo.TwoLetterISOLanguageName == "en")
            {
                procesada = fecha.Replace("nd", "")
                             .Replace("th", "")
                             .Replace("rd", "")
                             .Replace("st", "");
            }

            List<string> formatos = new List<string>(){
                "MMMM d, yyyy",
                "MMMM d yyyy",
                "MMM dd, yyyy",
                "MMMM dd yyyy",
                "MMMM yyyy",
                "yyyy",
                "yyyy?",
                "yyyy MMMM",
                "yyyy MMMM d",
                "yyyy MMMM dd",
                "yyyy-MM-dd",
                "yyyy-MM-dd",
                "yyyy-MM-dd",
            };

            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings?redirectedfrom=MSDN
            foreach (var formato in formatos)
            {
                if (DateTime.TryParseExact(fecha, formato, cultureInfo, DateTimeStyles.None, out date))
                {
                    return date;
                }
            }

            throw new FormatException("Formato de fecha desconocido.");
        }
    }

}

