using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class StocView : ContentPage
    {
        public StocView()
        {
            InitializeComponent();
        }
        public async void SubcategoriesView(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SubcategoriesView());
        }
        public async void AddProductView(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddProductView());
        }
    }
}
