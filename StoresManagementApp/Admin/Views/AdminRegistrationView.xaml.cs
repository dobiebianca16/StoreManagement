using System;
using System.Collections.Generic;
using StoresManagementApp.Services;
using Xamarin.Forms;

namespace StoresManagementApp.Admin.Views
{
    public partial class AdminRegistrationView : ContentPage
    {
        public AdminRegistrationView()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var response = await UserService.ServiceClientInstance.RegisterAdminUser(Username.Text, Password.Text);
            if (response == true)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Admin User Created Sucessfully", "Ok");
                await Navigation.PopModalAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", " Contul exista deja", "Ok");
            }

        }
    }
}
