using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Recursos
    {
        //Encriptacion de texto SHA256
        public static string ConvertirSHA256(string texto) { 

            StringBuilder sb = new StringBuilder();
            //Usar referencia de System.Security.Cryptography
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach(byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }

            return sb.ToString();

        }

        static bool EnviarCorreoAsesor (string correo, string asunto, string mensaje) {
            bool resultado = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo); //para quien
                mail.From = new MailAddress("charliewhite270998@gmail.com"); //de quien
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;
                //uzpx dybo kqdj prio
                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("charliewhite270998@gmail.com", "uzpx dybo kqdj prio"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl= true
                };
                
                smtp.Send(mail);
                resultado = true;

            }catch(Exception ex)
            {
                resultado = false;
            }

            return resultado;
        }

        public static bool EnviarCorreoAsesor(string asunto, string mensaje)
        {
            try
            {
                // Configurar el cliente SMTP
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("charliewhite270998@gmail.com", "uzpx dybo kqdj prio"),
                    EnableSsl = true,
                };

                // Crear el mensaje de correo
                var correo = new MailMessage
                {
                    From = new MailAddress("charliewhite270998@gmail.com"),
                    Subject = asunto,
                    Body = mensaje,
                    IsBodyHtml = true,
                };

                // Agregar destinatario (correo de la empresa)
                correo.To.Add("charliewhite270998@gmail.com");

                // Enviar correo
                smtpClient.Send(correo);

                return true; // Envío exitoso
            }
            catch (Exception ex)
            {
                // Manejar el error en caso de que falle el envío
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
                return false; // Envío fallido
            }
        }

    }
}
