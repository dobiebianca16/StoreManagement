using System;
using System.Collections.Generic;
using StoresManagementApp.Model;
using StoresManagementApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class MeniuView : ContentPage
    {
    
        public MeniuView()
        {
            InitializeComponent();
     
        
        }

    

        public async void StocView(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StocView());
        }
        
    }
}
