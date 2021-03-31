using System;
using StoresManagementApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoresManagementApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            /* string uname = Preferences.Get("Username", String.Empty);
             if(string.IsNullOrEmpty(uname))
             {
                 MainPage = new LoginView();
             }
             else
             {
                 MainPage = new MeniuView(userId);
             }*/

            //MainPage = new NavigationPage(new SettingPage());
            
           MainPage = new NavigationPage(new LoginView());
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
