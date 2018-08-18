using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SPECFILE_M
{
    class FilesReader
    {
        public void ReadDirectories()
        {
            string sourceFolder = @"C:\Users\mansha\Documents\TestCopy\";

            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string recipients = $"{folder}\\MailAddressesTo.txt";
                string attachments = $"{folder}\\Attachments.txt";
                string body = File.ReadAllText($"{folder}\\body.txt");
                MailMessage message = new MailMessage();
                message.From = new MailAddress("put.hassanmansoor@gmail.com");
                ReadFileToAddRecipients(recipients, message);
                message.Subject = "Korespondencja niejawna";
                message.Body = body;
                message.IsBodyHtml = true;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                message.Priority = MailPriority.High;
                ReadFileToAddAttachments(attachments,message);
                try
                {
                    send(message);
                }
                catch (SmtpFailedRecipientException ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }

        public void ReadFileToAddRecipients(string filePath, MailMessage message)
        {
           foreach( string recipient in File.ReadLines(filePath))
            {
                message.To.Add(new MailAddress(recipient));
            }
           
        }

        public void ReadFileToAddAttachments(string filePath, MailMessage message)
        {
            foreach (string attachment in File.ReadLines(filePath))
            {
                Attachment a = new Attachment(attachment);
                message.Attachments.Add(a);                    
                
            }
        }

        public void send(MailMessage message)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("put.hassanmansoor@gmail.com", "Hobnob101");
            smtp.Port = 587; //reading from web.config  
            smtp.Send(message);
        }
    }
}
