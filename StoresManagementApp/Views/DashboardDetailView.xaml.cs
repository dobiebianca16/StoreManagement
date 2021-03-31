using System;
using System.Collections.Generic;
using StoresManagementApp.Admin.Model;
using Xamarin.Forms;

namespace StoresManagementApp.Views
{
    public partial class DashboardDetailView : ContentPage
    {
        public DashboardDetailView(TaskModel taskModel)
        {
            InitializeComponent();
           
            TaskTitle.Text = taskModel.TaskTitle.ToString();
 
            MyList.ItemsSource = taskModel.employeeTasks;
        }
        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
