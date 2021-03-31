using System;
using System.Collections.Generic;
using System.Linq;
using StoresManagementApp.Model;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class SubcategoriesView : ContentPage
    {
        public SubcategoriesView()
        {
            InitializeComponent();
        }
        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var category = e.CurrentSelection.FirstOrDefault() as Category;
            if (category == null)
                return;
            await Navigation.PushModalAsync(new CategoryView(category));
            ((CollectionView)sender).SelectedItem = null;
        }
        async void BackToStoc(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
