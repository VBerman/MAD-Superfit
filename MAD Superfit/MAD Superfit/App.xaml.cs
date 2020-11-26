using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAD_Superfit
{
    public partial class App : Application
    {
        public static HttpClient http = new HttpClient();
        public static string AppId = "8e7554dd";
        public static string AppKey = "cd9d9003516a99d783f93e0aac1a9098";

        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
