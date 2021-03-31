using System;
using System.Collections.Generic;
using System.Linq;
using StoresManagementApp.Model;
using StoresManagementApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class SearchResultsView : ContentPage
    {
        SearchResultViewModel srvm;
        public SearchResultsView(string searchText)
        {
            InitializeComponent();
            srvm = new SearchResultViewModel(searchText);
            this.BindingContext = srvm;
            LabelName.Text = $"Welcome {Preferences.Get("Username", "Guest")}";
        }
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

         async void  CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedProduct= e.CurrentSelection.FirstOrDefault() as Product;
            if (selectedProduct == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailView(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
            
        }
    }
}
