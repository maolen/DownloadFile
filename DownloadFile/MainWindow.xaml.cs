using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace DownloadFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string UrlAddress{get; set;}
        private void DownloadClick(object sender, RoutedEventArgs e)
        {
            UrlAddress = urlAddress.Text;
            progressBar.Visibility = Visibility.Visible;
            var thread = new Thread(DownloadFile);
            thread.IsBackground = true;
            thread.Start();
            progressBar.Visibility = Visibility.Hidden;
            MessageBox.Show("Файл загружен");
        }

        private void DownloadFile()
        {
            using (var client = new WebClient())
            { 
                client.DownloadFile(UrlAddress, $@"{UrlAddress.Substring(UrlAddress.Length - 5)}");
            }
        }
    }
}
