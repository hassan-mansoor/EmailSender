using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPECFILE_M
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static System.Timers.Timer aTimer;
        List<string> attachment_lst = new List<string>();

        public MainWindow()
        {
            InitializeComponent();           

        }

        public void Start(object sender, RoutedEventArgs e)
        {
            CopyDirectories copy = new CopyDirectories();
            if (copy.CheckWEJSCIEISEmpty())
            {
                copy.Init();
            }            
            FilesReader reader = new FilesReader();
            reader.AttachmentList = attachment_lst;
            reader.ReadDirectories();
            //logger messages
            copy.MessageLogger.ForEach(msg =>
            {
                logger.Text += msg.ToString()+ "\n"; 

            });
            reader.MessageLogger.ForEach(msg =>
            {
                logger.Text += msg.ToString()+ "\n"; 
            });

            aTimer = new System.Timers.Timer(60000);
            aTimer.Elapsed += new ElapsedEventHandler((source, args) => {
                CopyDirectories copy1 = new CopyDirectories();
                if (copy1.CheckWEJSCIEISEmpty())
                {
                    copy1.Init();
                }
                FilesReader reader1 = new FilesReader();
                reader1.AttachmentList = attachment_lst;
                reader1.ReadDirectories();
                //logger messages
                this.Dispatcher.Invoke(() => {
                    copy1.MessageLogger.ForEach(msg =>
                    {
                        logger.Text += msg.ToString() + "\n";

                    });
                    reader1.MessageLogger.ForEach(msg =>
                    {
                        logger.Text += msg.ToString() + "\n";
                    });
                });
            });
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

        }


        public void Upload(object sender, RoutedEventArgs e)
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
                }
                else
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

