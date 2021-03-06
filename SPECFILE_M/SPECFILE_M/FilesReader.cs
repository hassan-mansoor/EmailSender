﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private List<string> _AttachmentList;
        public List<string> MessageLogger = new List<string>();       

        public void ReadDirectories()
        {
            string sourceFolder = ConfigurationManager.AppSettings["BUFORDirectory"];
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                MessageLogger.Add("Start Reading email files form directory: "+ folder.Split('\\').Last());
                string recipients = folder+"\\MailAddressesTo.txt";
                string attachments = folder+"\\Attachments.txt";
                string body = File.ReadAllText(folder+"\\body.txt");
                MailMessage message = new MailMessage();
                message.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                ReadFileToAddRecipients(recipients, message);
                message.Subject = "Korespondencja niejawna";
                message.Body = CreateMessageBody(body);
                message.IsBodyHtml = true;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                message.Priority = MailPriority.High;
                ReadFileToAddAttachments(attachments,message);
                AddExternalAttachments(message);
                try
                {
                    MessageLogger.Add("Sending Email to recipients");
                    send(message);
                    MessageLogger.Add("Sending Email Successful");
                    CopyDirectories copyDirectory = new CopyDirectories();
                    copyDirectory.RemoveDirectoryRecursively(folder);
                    MessageLogger.Add("Removing all files and directory: " + folder.Split('\\').Last());
                }
                catch (SmtpFailedRecipientException ex)
                {
                    MessageLogger.Add("Error in Sending email"+ ex.Message.ToString());
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

        private string CreateMessageBody(string message)
        {
            string body = string.Empty;
            StreamReader reader = new StreamReader("../../Templates/Template1.html");
            body = reader.ReadToEnd();
            body = body.Replace("{message}", message);
            return body;
        }

        public void AddExternalAttachments(MailMessage message)
        {
            if (_AttachmentList.Count > 0)
            {
                _AttachmentList.ForEach(attachment =>
                {
                    Attachment a = new Attachment(attachment);
                    message.Attachments.Add(a);
                });
            }
        }

        public void send(MailMessage message)
        {            
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["Host"];
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"]);
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]); //reading from config.json  
            smtp.Send(message);            
        }

        public List<string> AttachmentList
        {
            get
            {
                return this._AttachmentList;
            }
            set
            {
                this._AttachmentList = value;
            }
        }
    }
}
