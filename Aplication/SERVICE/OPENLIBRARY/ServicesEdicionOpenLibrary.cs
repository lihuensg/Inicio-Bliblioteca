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
                mUrl = String.Format("https://openlibrary.org/books/{0}.json", pFiltros["Id"]);
            }
            else if (pFiltros.ContainsKey("ISBN"))
            {
                mUrl = String.Format("https://openlibrary.org/isbn/{0}.json", pFiltros["ISBN"]);
            }

            try
            {
                dynamic mResponseJson = HttpJsonRequest.Obtener(mUrl);
                DTOEdicion edicion = new DTOEdicion();
                string isbn = null;

                if (mResponseJson.ContainsKey("isbn_13"))
                {
                    isbn = (string)mResponseJson["isbn_13"][0];
                }
                else if (mResponseJson.ContainsKey("isbn_10"))
                {
                    isbn = (string)mResponseJson["isbn_10"][0];
                }

                if (isbn == null) { return null; }

                edicion.Isbn = isbn;
                edicion.Portada = String.Format("https://covers.openlibrary.org/b/isbn/{0}-L.jpg", isbn);

                if (mResponseJson.ContainsKey("number_of_pages"))
                {
                    edicion.NumeroPaginas = mResponseJson["number_of_pages"];
                }

                edicion.AnioEdicion = mResponseJson["revision"];

                if (mResponseJson.ContainsKey("publish_date"))
                {
                    string fechaString = (string)mResponseJson["publish_date"];
                    try
                    {
                        edicion.FechaPublicacion = PasarFecha(fechaString, new CultureInfo("en-US"));
                    }
                    catch (FormatException ex)
                    {
                        // Error fecha invalida
                        LogManager.GetLogger().Error(ex,"Error: Fecha invalida '{0}'. {1}", fechaString, ex.Message);
                    }
                }

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

