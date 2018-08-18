using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EmailComposer.Writter;

namespace EmailComposer.Mail
{
    class Mailer
    {
        public string CreateMaile(MessageModel Mail)
        {
            string toaster_message = string.Empty;
            try {
                  MailMessage message = new MailMessage();
                  message.From = new MailAddress(Mail.From);
                  AddRecipients(Mail.To, message);
                  message.Subject = Mail.Subject;
                  message.Body = CreateMailBody(Mail.Body);
                  message.IsBodyHtml = true;
                  AddAttachments(message, Mail.Attachments);
                  bool AreFilesCreated = SaveToFile(Mail);
                if (AreFilesCreated)
                {
                    toaster_message = "\nEmail Files Composed Successfully\n";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in sendEmail:" + ex.Message);
                toaster_message =  "\n"+ ex.Message +"\n";
            }

            return toaster_message;
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
            if (attachment_lst.Count > 0)
            {
                attachment_lst.ForEach(attachment =>
                {
                    Attachment a = new Attachment(attachment);
                    message.Attachments.Add(a);
                });
            }
        }

        private void AddRecipients(List<string> recipients, MailMessage message)
        {
            recipients.ForEach(to => message.To.Add(
                new MailAddress(to)
                ));
        }

        private bool SaveToFile(MessageModel message)
        {
            WriteToFile writter = new WriteToFile();
            writter.CreateSubDirectoryWithTimeStamp();
            writter.FileWritter("subject", message.Subject);
            writter.FileWritter("body", message.Body);
            writter.FileWritter("MailAddressFrom", message.From);
            writter.FileWritter("MailAddressesTo", message.To.ToList());
            writter.FileWritter("Attachments", message.Attachments.ToList());

            return true;
        }
    }
}
