using System;
using System.Collections.Generic;
using StoresManagementApp.Admin.ViewModels;
using Xamarin.Forms;

namespace StoresManagementApp.Admin.Views
{
    public partial class AdminLoginView : ContentPage
    {
        public AdminLoginView()
        {
            InitializeComponent();
            BindingContext = new AdminViewModel(Navigation);
        }
        void  Button_Clicked(System.Object sender, System.EventArgs e)
        {
             Navigation.PushModalAsync(new AdminRegistrationView());
        }

        
    }
}
