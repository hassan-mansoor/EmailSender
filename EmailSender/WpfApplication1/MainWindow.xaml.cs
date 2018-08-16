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

namespace EmailSender
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Clicked";
            Mail.Mailer mailer = new Mail.Mailer();
            mailer.CreateMaile(attachment_lst);
          
        }

        private void Button_Upload(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            Nullable<bool> result = fileDialog.ShowDialog();
            if (result == true)
            {
                string filename = fileDialog.FileName;
                attachment_lst.Add(filename);
                this.Title = filename;

            }

        }
    }
}
