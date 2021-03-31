using System;
using System.Collections.Generic;
using StoresManagementApp.Model;
using StoresManagementApp.ViewModels;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class ProductDetailView : ContentPage
    {
        ProductsDetailViewModel pvm;

        public ProductDetailView(Product product)
        {
            InitializeComponent();
            pvm = new ProductsDetailViewModel(product);
            this.BindingContext = pvm;
        }
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
