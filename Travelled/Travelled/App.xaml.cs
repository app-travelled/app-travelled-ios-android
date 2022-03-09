using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("Samantha.ttf")]
[assembly: ExportFont("Astral_Sisters.ttf")]
[assembly: ExportFont("CaviarDreams.ttf")]

namespace Travelled
{

    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            /*if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = Color.Transparent };
                
            }
            else
            {*/
                MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.Transparent };
            //}
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
