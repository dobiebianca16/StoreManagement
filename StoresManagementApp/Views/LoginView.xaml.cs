using System;
using System.Collections.Generic;
using StoresManagementApp.Admin.Views;
using StoresManagementApp.Services;
using StoresManagementApp.ViewModels;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new AdminLoginView());
        }

        async void Register_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterView());
        }
    }
}
