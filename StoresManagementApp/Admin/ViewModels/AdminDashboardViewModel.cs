using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using StoresManagementApp.Admin.Model;
using StoresManagementApp.Model;
using StoresManagementApp.Services;
using StoresManagementApp.ViewModels;
using Xamarin.Forms;


namespace StoresManagementApp.Admin.ViewModels
{
    public class AdminDashboardViewModel:BaseViewModel
    {
        ObservableCollection<TaskModel> _employeeTasks;
        public ObservableCollection<TaskModel> employeeTasks
        {
            get { return _employeeTasks; }
            set
            {
                _employeeTasks = value;
                OnPropertyChanged();
            }
        }
        public string EmployeeId { get; set; }

        public ICommand DeleteCommand { get; }
        public ICommand UpdateDatabaseCommand { get; set; }
        public User _SelectedContents { get; set; }

        public AdminDashboardViewModel(User SelectedContents)
        {
            EmployeeId = SelectedContents.UserId.ToString();
            _SelectedContents = SelectedContents;
            GetUserTasks();
            DeleteCommand = new Command(DeleteLabelSelected);
            UpdateDatabaseCommand = new Command(async () => await UpdateUserDatabase());

        }

        private async Task UpdateUserDatabase()
        {

        }
        private async void DeleteLabelSelected(object obj)
        {
            var content = obj as TaskModel;
            employeeTasks.Remove(content);
            var response = await UserService.ServiceClientInstance.DeleteDatabaseContent(content);
            if(response==true )
            {
                await App.Current.MainPage.DisplayAlert("Alert", "File Deleted Successfully", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Server Issue", "Ok");
            }
        }
        private async void GetUserTasks()
        {
            var response = await UserService.ServiceClientInstance.GetEmployeeTasks(EmployeeId);
            employeeTasks = new ObservableCollection<TaskModel>(response);
        }
    }
}
