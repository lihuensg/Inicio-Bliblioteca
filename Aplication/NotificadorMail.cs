using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace Aplication
{
    public class NotificadorMail : INotificador
    {
        string mailRemitente;
        string password;
        int puerto;
        bool eneableSSL;
        string nombreCuenta;
        public NotificadorMail(string pMailRemitente, string pPassword, int pPuerto, bool pEneableSSL, string pNombreCuenta)
        {
            mailRemitente = pMailRemitente;
            password = pPassword;
            puerto = pPuerto;
            eneableSSL = pEneableSSL;
            nombreCuenta = pNombreCuenta;
        }

        public string MailRemitente
        {
            get { return this.mailRemitente; }

        }
        public string Password
        {
            get { return this.password; }
        }
        public bool EneableSSL
        {
            get { return this.eneableSSL; }

        }
        
        public void Enviar(string pMailDestino, string pSubject, string pTexto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nombreCuenta, mailRemitente));
            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", pMailDestino));
            message.Subject = pSubject;

            message.Body = new TextPart("plain")
            {
                Text = pTexto
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("@gmail.com", password);

                client.Send(message);
                client.Disconnect(true);
            };
        }
    }
};
