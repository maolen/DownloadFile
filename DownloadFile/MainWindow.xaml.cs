using System.Net;
using System.Threading;
using System.Windows;

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
