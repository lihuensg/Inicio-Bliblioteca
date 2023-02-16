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


namespace Aplication
{
    public class ServiceEdicionesOpenLibrary : IServicesEdicion
    {
        private readonly static ServiceEdicionesOpenLibrary _instance = new ServiceEdicionesOpenLibrary();

        private ServiceEdicionesOpenLibrary()
        {
        }

        public static ServiceEdicionesOpenLibrary Instance
        {
            get
            {
                return _instance;
            }
        }
        public DTOEdicion Buscar(Dictionary<string, string> pFiltros)
        {
            // Establecimiento del protocolo ssl de transporte
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (pFiltros.Count == 0)
            {
                throw new Exception("Se nececita filtrar por ISBN o ID de openlibrary");
            }
            string mUrl = "";
            if (pFiltros.ContainsKey("Id"))
            {
                throw new NotImplementedException();
            }
            else if (pFiltros.ContainsKey("ISBN"))
            {
                mUrl = String.Format("https://openlibrary.org/api/books?bibkeys=ISBN:{0}&format=json&jscmd=data", pFiltros["ISBN"]);
            }

            try
            {
                dynamic mResponseJson = HttpJsonRequest.Obtener(mUrl);
                DTOEdicion edicion = new DTOEdicion();
                string isbn = null;
                string lccn = null;

                if (mResponseJson != null) {
                    var llave = String.Format("ISBN:{0}", pFiltros["ISBN"]);
                    mResponseJson = mResponseJson[llave];

                    if (mResponseJson == null) {
                        return null;
                    }
                } else {
                    return null;
                }


                if (mResponseJson.ContainsKey("identifiers")) {
                    if (mResponseJson["identifiers"].ContainsKey("isbn_13")) {
                        isbn = (string)mResponseJson["identifiers"]["isbn_13"][0];
                    } else if (mResponseJson["identifiers"].ContainsKey("isbn_10")) {
                        isbn = (string)mResponseJson["identifiers"]["isbn_10"][0];
                    }

                    if (mResponseJson["identifiers"].ContainsKey("lccn")) {
                        lccn = (string)mResponseJson["identifiers"]["lccn"][0];
                    }
                }


                // FIX: El lccn es obligatorio ya que se usa como identificador para la obra,
                // pero la api a veces no tiene lccn en la respuesta
                if (isbn == null || lccn == null) { return null; }

                edicion.Isbn = isbn;
                edicion.Portada = String.Format("https://covers.openlibrary.org/b/isbn/{0}-L.jpg", isbn);

                if (mResponseJson.ContainsKey("number_of_pages"))
                {
                    edicion.NumeroPaginas = mResponseJson["number_of_pages"];
                }

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
                        LogManager.GetLogger().Error(ex,"Error: Fecha invalida '{0}'. {1}", fechaString, ex.Message);
                    }
                }

                // seteamos los datos de la obra
                edicion.Obra = new DTOObra();
                edicion.Obra.Generos = new List<string>();
                if (mResponseJson.ContainsKey("subjects")) {
                    foreach (var genero in mResponseJson.subjects) {
                        edicion.Obra.Generos.Add((string)genero.name);
                    }
                }

                for(int i = 0; i < mResponseJson.authors.Count; i++) {
                    edicion.Obra.Autores = (string)mResponseJson.authors[i].name;
                    if (i != mResponseJson.authors.Count - 1) {
                        edicion.Obra.Autores += ", ";
                    }
                }

                edicion.Obra.Titulo = mResponseJson.title;
                edicion.Obra.Descripcion = mResponseJson.subtitle;
                edicion.Obra.Lccn = lccn;

                edicion.Obra.Ediciones = new List<DTOEdicion>();

                return edicion;
            }
            catch (ExcepcionConsultaWeb ex)
            {
                LogManager.GetLogger().Error(ex, "No se puede realizar la consulta en el servidor");
            }
            catch (ExcepcionRespuestaInvalida ex1)
            {
                LogManager.GetLogger().Error(ex1,"No se encontro respuesta");
            }

            return null;
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

