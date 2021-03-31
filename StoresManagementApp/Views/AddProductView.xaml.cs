using System;
using System.Collections.Generic;
using StoresManagementApp.Model;
using StoresManagementApp.Services;
using StoresManagementApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class AddProductView : ContentPage
    {
        
        public AddProductView()
        {
            InitializeComponent();
            BindingContext = new AddProductsViewModel();
            

        }

      
     }
}
