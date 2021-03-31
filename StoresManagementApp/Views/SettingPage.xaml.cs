using System;
using System.Collections.Generic;
using StoresManagementApp.Helpers;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }
        async void ButtonCategories_Clicked(System.Object sender, System.EventArgs e)
        {
            var acd = new AddCategoryData();
            await acd.AddCategoriesAsync();
        }
        async void ButtonSubcategories_Clicked(System.Object sender, System.EventArgs e)
        {
            var acd = new AddSubcategoriesData();
            await acd.AddSubcategoriesAsync();
        }
        async void ButtonCart_Clicked(System.Object sender, System.EventArgs e)
        {
            var bbc = new CreateCartTable();
            if (bbc.CreateTable())
               await  DisplayAlert("Succes", "CartTable created", "ok");
            else
               await  DisplayAlert("Error", "Error while creating", "ok");
        }
    }
}
