using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoresManagementApp.ViewModels;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
        async void BackCommand(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}
