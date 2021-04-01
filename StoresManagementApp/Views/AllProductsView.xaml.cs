﻿using System;
using System.Collections.Generic;
using System.Linq;
using StoresManagementApp.Model;
using StoresManagementApp.ViewModels;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class AllProductsView : ContentPage
    {
        
        public AllProductsView()
        {
            InitializeComponent();
           
        }
        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var product = e.CurrentSelection.FirstOrDefault() as Product;
            if (product == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailView(product));
            ((CollectionView)sender).SelectedItem = null;
        }
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new AddProductView());
        }
    }
}
