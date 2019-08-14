using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;

namespace XamAppWithYtE
{
    public partial class App : Application
    {
        public YoutubeClient Ytclient { get; }

        public App(HttpClient httpClient)
        {
            InitializeComponent();
            Ytclient = new YoutubeClient(httpClient);

            MainPage = new MainPage(Ytclient);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
