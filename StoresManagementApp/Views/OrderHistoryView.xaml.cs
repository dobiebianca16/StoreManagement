using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class OrderHistoryView : ContentPage
    {
        public OrderHistoryView()
        {
            InitializeComponent();
            LabelName.Text = @"Order's History of  " + Preferences.Get("Username", "Guest") + ",";
        }
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
