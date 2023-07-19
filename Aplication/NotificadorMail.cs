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

        public bool EnviarGenerico(string titulo, string cuerpo, Usuario destinatario)
        {
            string destinoNombre = destinatario.NombreUsuario;
            string destinoMail = destinatario.Mail;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(serverAuthUsername, mailRemitente));
            message.To.Add(new MailboxAddress(destinoNombre, destinoMail));
            message.Subject = titulo;

            message.Body = new TextPart("plain")
            {
                Text = cuerpo
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(this.smtpServerName, this.puerto, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(this.serverAuthUsername, this.serverAuthPassword);

                    client.Send(message);
                    client.Disconnect(true);
                };
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Logear el problema
                return false;
            }
        }
    }
};
