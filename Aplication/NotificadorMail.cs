using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class NotificadorMail : INotificador
    {
        string mailRemitente;
        string password;
        int puerto;
        bool eneableSSL; 
        public NotificadorMail(string pMailRemitente, string pPassword, int pPuerto, bool pEneableSSL)
        {
            mailRemitente = pMailRemitente;
            password = pPassword;
            puerto = pPuerto;
            eneableSSL = pEneableSSL;
        }

       public string MailRemitente
       {
           get{ return this.mailRemitente;}
            
       }
       public string Password 
       {
           get{ return this.password;}
       }
       public bool EneableSSL
       {    get{ return this.eneableSSL;}

       }
       public void Enviar(string pMailDestino, string pSubject,string pTexto)
       {
           
       }
    }
}