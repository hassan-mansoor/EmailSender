using EmailComposer.Writter;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace EmailComposer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> attachment_lst = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Mailing System";
            WriteToFile writter = new WriteToFile();
            writter.CreateDirectory();
        }

        private void ComposeMail(object sender, RoutedEventArgs e)
        {
            lblToster.Content = string.Empty;
            lblToster.Visibility = Visibility.Hidden;
            if (From.Text.Trim() != String.Empty && To.Text.Trim() != string.Empty)
            {                
                Mail.Mailer mailer = new Mail.Mailer();
                Mail.MessageModel messageModel = new Mail.MessageModel
                {
                    From = From.Text,
                    To = To.Text.Split(';').ToList(),
                    Attachments = attachment_lst,
                    Subject = Subject.Text,
                    Body = Message.Text
                };

                string created = mailer.CreateMaile(messageModel);
                lblToster.Visibility = Visibility.Visible;
                lblToster.Foreground = System.Windows.Media.Brushes.AliceBlue;
                lblToster.Content = created;

            } else
            {
                lblToster.Content += "\nPlease check To and From field cannot be empty.\n";
                lblToster.Visibility = Visibility.Visible;                
            }
          
        }

        private void Upload(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            Nullable<bool> result = fileDialog.ShowDialog();
            lblToster.Content = string.Empty;
            lblToster.Visibility = Visibility.Hidden;
            if (result == true)
            {
                string filename = fileDialog.FileName;
                txtAttachment.Text = filename;                               
                this.Title = filename;
                FileInfo fileInfo = new FileInfo(filename);
                double fileSize = fileInfo.Length / (1024 * 1024);
                if (fileSize <= 25)
                {
                    attachment_lst.Add(filename);
                    this.listView.Items.Add(new AttachFiles() { fileName = filename, fileSize = fileSize.ToString() + " MB" });
                } else
                {
                    lblToster.Content += "\nMaximum file size is 25 MB.\n";
                    lblToster.Visibility = Visibility.Visible;
                }
            }
        }
    }

    class AttachFiles
    {
        public string fileName { get; set; }
        public string fileSize { get; set; }
    }
}
