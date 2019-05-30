using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PaceScrape.Classes
{
    public class Reusables
    {
        public void SendEmail(string subject, string emailfrom, string emailto, string emailbody)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Host = ConfigurationManager.AppSettings["SMTP.Server"];
                smtpClient.Port = Convert.ToInt16(ConfigurationManager.AppSettings["SMTP.Port"]);

               MailMessage mailMessage = new MailMessage(
                    emailfrom,
                    emailto,
                    subject,
                    emailbody);
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;

                smtpClient.Send(mailMessage);
            }
        }
    }
}