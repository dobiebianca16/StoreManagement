using System;
using System.Collections.Generic;
using System.Linq;
using StoresManagementApp.Model;
using StoresManagementApp.ViewModels;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class ProductsbyCateg : ContentPage
    {
        ProductsViewModel cvm;
        private Subcategory subcategory;

        

        public ProductsbyCateg(Subcategory subcategory)
        {
            InitializeComponent();
            cvm = new ProductsViewModel(subcategory);
            this.BindingContext = cvm;
        }

        async void ImageButton_Click(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var product = e.CurrentSelection.FirstOrDefault() as Product;
            if (product == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailView(product));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
