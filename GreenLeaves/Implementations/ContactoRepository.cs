using GreenLeaves.Interfaces;
using GreenLeaves.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GreenLeaves.Implementations
{
    public class ContactoRepository : IContacto
    {
        private GreenLeavesContext context = null;

        public async Task<Contacto> AgregarContacto(Contacto oContacto)
        {
            context = new GreenLeavesContext();
            try
            {
                if (oContacto.Fecha == DateTime.MinValue) 
                {
                    oContacto.Fecha = DateTime.Now;
                }
                if (oContacto.IsoCiudad.Length > 3) 
                {
                    oContacto.IsoCiudad = oContacto.IsoCiudad.Substring(0, 3);
                }

                EntityEntry<Contacto> oContactResult = await context.Contacto.AddAsync(oContacto);
                int iResult = await context.SaveChangesAsync();
                if (iResult >= 0)
                {
                    EnviarEmail(oContacto);
                }
                return oContactResult.Entity;
            }
            catch (Exception)
            {
                return new Contacto();
            }
        }

        private void EnviarEmail(Contacto oContacto)
        {
            try
            {
                bool bFlag = false;
                MailMessage newMail = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                newMail.From = new MailAddress(MyConfig.GetValue<string>("AppSettings:Email"),
                                               MyConfig.GetValue<string>("AppSettings:Email"));
                newMail.To.Add(oContacto.Email);
                newMail.Subject = "Mensaje de Green Leaves";
                newMail.IsBodyHtml = true;
                newMail.Body = @"<h4>Estimado {{contacto.nombre}}</h4> 
                                <p> Hemos recibido sus datos y nos pondremos en contacto con usted en la brevedad posible. Enviaremos un correo 
                                con información a su cuenta: <a target = ""_blank"" href = ""mailto:" + oContacto.Email + @""">" + oContacto.Email + "</a></p>";
                client.EnableSsl = true;
                client.Port = 465;
                client.Credentials = new System.Net.NetworkCredential(MyConfig.GetValue<string>("AppSettings:Email"),
                                                                      MyConfig.GetValue<string>("AppSettings:Email_Password"));
                client.SendAsync(newMail, bFlag);
            }
            catch { }
        }
    }
}
