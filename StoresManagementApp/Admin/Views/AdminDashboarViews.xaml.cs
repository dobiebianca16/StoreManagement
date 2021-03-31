using System;
using System.Collections.Generic;
using StoresManagementApp.Model;
using StoresManagementApp.Services;
using Xamarin.Forms;
using StoresManagementApp.Admin.Model;
using StoresManagementApp.Views;

namespace StoresManagementApp.Admin.Views
{
    public partial class AdminDashboarViews : ContentPage
    {
        public AdminDashboarViews()
        {
            InitializeComponent();
            GetListofEmployee();
        }

        private async void GetListofEmployee()
        {
            var response = await UserService.ServiceClientInstance.GetRegisteredUsers();
            MyList.ItemsSource = response;
        }
        async void Stoc_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StocView());
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var CellContents = ((Button)sender).BindingContext as User;

            //Step1 : Add task title
            var addtasktitle = await DisplayPromptAsync("Question", "What is the task name for  " + CellContents.Username + " User ");

            //Step 2 : Add total no of tasks
            var addtotaltasks = await DisplayPromptAsync("Question", "How many task assign to  " + CellContents.Username, keyboard: Keyboard.Numeric);

            int totaltasks = Convert.ToInt32(addtotaltasks);


            //Step 3 : Create a new task for the user
            TaskModel taskModel = new TaskModel()
            {
                EmployeeId = CellContents.UserId,
                TaskId = Guid.NewGuid(),
                TaskTitle = addtasktitle,
                employeeTasks = new List<EmployeeTask>()
            };



            int i = 1;
            do
            {
                string result = await DisplayPromptAsync("Question", "Add Task " + i + " to " + CellContents.Username);

                EmployeeTask employeeTask = new EmployeeTask()
                {
                    TaskName = result
                };

                taskModel.employeeTasks.Add(employeeTask);

                i++;

            } while (i <= totaltasks);

            //Step 6 : Push the task to the database

            await UserService.ServiceClientInstance.AssignTaskToEmployee(taskModel);

            await DisplayAlert("Alert", "Task sucessfully assigned to " + CellContents.Username, " OK ");

            //Go back to the 1st Screen


        }

        async void MyList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var content = e.SelectedItem as User;
            await Navigation.PushModalAsync(new AdminDashboardDetailView(content));
            MyList.SelectedItem = null;

        }
        async void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}