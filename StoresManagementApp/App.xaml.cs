using System;
using StoresManagementApp.Model;
using StoresManagementApp.ViewModels;
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

          

             string uname = Preferences.Get("Username", String.Empty);
             if(string.IsNullOrEmpty(uname))
             {
                 MainPage = new LoginView();
             }
             else
             {
                MainPage = new AppShell();
             }

            //MainPage = new NavigationPage(new SettingPage());

            //MainPage = new NavigationPage(new AllProductsView());
            //MainPage = new NavigationPage(new LoginView());
            //MainPage = new AppShell() ;
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
