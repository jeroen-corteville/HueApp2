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
using System.Security.Cryptography.X509Certificates;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Analytics.v3;

namespace HueApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private X509Certificate2 certi;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client= new HttpClient();
            String requestUri = "http://10.0.0.162/api/NextNature/lights/1/state";
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
            
        private void initGoogleConnection()
        {
            certi = new X509Certificate2(@"key.p12", "notasecret", X509KeyStorageFlags.Exportable);

            String serviceAccountEmail = "932199827264-3tf7l96rdmgbatjhisr2vb1l26o8gs9h@developer.gserviceaccount.com";
            string[] scopes = new string[] {
                AnalyticsService.Scope.Analytics
            };

            ServiceAccountCredential credential = new ServiceAccountCredential(
              new ServiceAccountCredential.Initializer(serviceAccountEmail)
              {
                  Scopes = scopes
              }.FromCertificate(certi));

            AnalyticsService service = new AnalyticsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Analytics Service"
            });

            Google.Apis.Analytics.v3.Data.RealtimeData rtd = service.Data.Realtime.Get("ga:7375990", "rt:activeUsers").Execute();
            MessageBox.Show("Actieve Users op dit moment: "+ rtd.Rows[0][0].ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            initGoogleConnection();
        }
    }
}
