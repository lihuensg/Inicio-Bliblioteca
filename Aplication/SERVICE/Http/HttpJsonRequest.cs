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

namespace Aplication.SERVICE.Http
{

    public class HttpJsonRequest
    {
        
        public static object Obtener(string mUrl)
        {
            // Establecimiento del protocolo ssl de transporte
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

            try
            {
                // Se ejecuta la consulta
                WebResponse mResponse = mRequest.GetResponse();

                // Se obtiene los datos de respuesta
                using (Stream responseStream = mResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                    try
                    {
                        // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                        return JsonConvert.DeserializeObject(reader.ReadToEnd());
                    }
                    catch (JsonReaderException ex)
                    {
                        throw new ExcepcionRespuestaInvalida("No se pudo deseralizar el Json", ex);
                    }



                }
            }
            catch (WebException ex)
            {
                WebResponse mErrorResponse = ex.Response;
                using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                {
                    StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                    String mErrorText = mReader.ReadToEnd();


                    throw new ExcepcionConsultaWeb("No se pudo consultar el servidor", ex);

                }
            }
        }
    }


}