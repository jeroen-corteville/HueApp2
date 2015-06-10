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
using System.Net.Http;

namespace HueApp
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

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client= new HttpClient();
            String requestUri = "http://10.0.0.129/api/NextNature/lights/1/state/";
            HttpContent content = new StringContent("{\"on\":true}");
            try
            {
                client.PutAsync(requestUri, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnTest_Click_1(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            String requestUri = "http://10.0.0.129/api/NextNature/lights/1/state/";
            HttpContent content = new StringContent("{\"on\":true}");
            try
            {
                client.PutAsync(requestUri, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
