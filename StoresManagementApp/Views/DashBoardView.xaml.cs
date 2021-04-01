using System;
using System.Collections.Generic;
using Microcharts;
using StoresManagementApp.Admin.Model;
using StoresManagementApp.Services;
using Xamarin.Forms;
using StoresManagementApp.Admin.Views;
using System.Collections;
using Entry = Microcharts.ChartEntry;
using SkiaSharp;

namespace StoresManagementApp.Views
{
    public partial class DashBoardView : ContentPage
    {
        public string UserId;

      
        public DashBoardView(string userId)
        {
            UserId = userId;
            InitializeComponent();
           
            GetMyTasks();
        }

        


        private async void GetMyTasks()
        {
            var response = await UserService.ServiceClientInstance.GetEmployeeTasks(UserId);
            MyList.ItemsSource = response;

        }
        async void OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SubcategoriesView());
        }

        async void MyList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
            {
                return;
            }
            var content = e.SelectedItem as TaskModel;

            await Navigation.PushModalAsync(new DashboardDetailView(content));

            ((ListView)sender).SelectedItem = null;

        }
      
    }
}
