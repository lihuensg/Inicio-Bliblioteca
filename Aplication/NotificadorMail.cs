using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace Aplication
{
    public class NotificadorMail : INotificador
    {
        string mailRemitente;
        string serverAuthPassword;
        string smtpServerName;
        int puerto;
        bool eneableSSL;
        string serverAuthUsername;

        public NotificadorMail(string pMailRemitente, string pSmtpServerName, int pPuerto, bool pEneableSSL, string pServerAuthUsername, string pServerAuthPassword)
        {
            smtpServerName = pSmtpServerName;
            mailRemitente = pMailRemitente;
            puerto = pPuerto;
            eneableSSL = pEneableSSL;
            serverAuthPassword = pServerAuthPassword;
            serverAuthUsername = pServerAuthUsername;
        }

        public string MailRemitente
        {
            get { return this.mailRemitente; }

        }
        public string Password
        {
            get { return this.serverAuthPassword; }
        }
        public bool EneableSSL
        {
            get { return this.eneableSSL; }

        }
        
        public bool Enviar(string pDestinoMail, string pDestinoNombre, string pSubject, string pTexto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(serverAuthUsername, mailRemitente));
            message.To.Add(new MailboxAddress(pDestinoNombre, pDestinoMail));
            message.Subject = pSubject;
                        
            message.Body = new TextPart("plain")
            {
                Text = pTexto
            };

            try {
                using (var client = new SmtpClient()) {
                    client.Connect(this.smtpServerName, this.puerto, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(this.serverAuthUsername, this.serverAuthPassword);

                    client.Send(message);
                    client.Disconnect(true);
                };
                return true;
            } catch(Exception ex) {
                // TODO: Logear el problema
                return false;
            }
        }
    }
};
