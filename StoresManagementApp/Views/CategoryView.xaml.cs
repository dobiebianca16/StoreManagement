using System;
using System.Collections.Generic;
using System.Linq;
using StoresManagementApp.Model;
using StoresManagementApp.ViewModels;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class CategoryView : ContentPage
    {
        CategoryViewModel cvm;
        public CategoryView(Category category)
        {
            InitializeComponent();
            cvm = new CategoryViewModel(category);
            this.BindingContext = cvm;
        }

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var subcategory = e.CurrentSelection.FirstOrDefault() as Subcategory;
            if (subcategory == null)
                return;
            await Navigation.PushModalAsync(new ProductsbyCateg(subcategory));
            ((CollectionView)sender).SelectedItem = null;
        }

    }
}