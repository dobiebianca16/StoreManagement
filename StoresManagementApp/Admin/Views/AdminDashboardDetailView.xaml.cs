using System;
using System.Collections.Generic;
using StoresManagementApp.Admin.ViewModels;
using Xamarin.Forms;
using StoresManagementApp.Admin.Model;
using StoresManagementApp.Model;
using StoresManagementApp.Services;

namespace StoresManagementApp.Admin.Views
{
    public partial class AdminDashboardDetailView : ContentPage
    {
        public AdminDashboardDetailView(User user)
        {
            InitializeComponent();
            BindingContext = new AdminDashboardViewModel(user);

        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Label lblClicked = (Label)sender;
            var item = (TapGestureRecognizer)lblClicked.GestureRecognizers[0];
            var tappedItem = item.CommandParameter as TaskModel;
        }
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
