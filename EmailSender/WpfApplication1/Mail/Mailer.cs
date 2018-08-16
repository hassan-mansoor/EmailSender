using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EmailSender.Mail
{
    class Mailer
    {
        public void CreateMaile(List<string> attachment_lst)
        {
            try {
                  MailMessage message = new MailMessage();
                  message.To.Add(new MailAddress("hassan_mansoor32@yahoo.com"));
                  message.From = new MailAddress("put.hassanmansoor@gmail.com");
                  message.Subject = "Sample subject";
                  message.Body = CreateMailBody("Example body this is sample message");
                  message.IsBodyHtml = true;
             //     AddAttachments(message, attachment_lst);
                  Console.WriteLine(message);
                  SmtpClient smtp = new SmtpClient();
                  smtp.Host = ConfigurationManager.AppSettings["Host"];
                  smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                  //System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                  //NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                  //NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                  smtp.UseDefaultCredentials = true;
                  smtp.Timeout = 10000;
                  smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"]);
                  smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                  smtp.Send(message);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in sendEmail:" + ex.Message);
            }
        }

        private string CreateMailBody( string message)
        {
            string body = string.Empty;
            StreamReader reader = new StreamReader("../../Templates/Template1.html");
            body = reader.ReadToEnd();
            body = body.Replace("{message}", message);
            return body;
        }

        private void AddAttachments(MailMessage message, List<string> attachment_lst)
        {
            attachment_lst.ForEach(attachment => {
                Attachment a = new Attachment(attachment);
                message.Attachments.Add(a);
            });

        }
    }
}
