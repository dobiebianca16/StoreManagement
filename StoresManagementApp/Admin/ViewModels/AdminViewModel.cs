using System;
using System.Threading.Tasks;
using StoresManagementApp.Admin.Views;
using StoresManagementApp.Services;
using StoresManagementApp.ViewModels;
using Xamarin.Forms;

namespace StoresManagementApp.Admin.ViewModels
{
    public class AdminViewModel:BaseViewModel
    {


        private string _Username;
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }

        public Command RegisterAdmin { get; set; }
        public Command LoginAdmin { get; set; }
        public INavigation SharedNav { get; }



        public AdminViewModel(INavigation navigation)
        {

            SharedNav = navigation;
            RegisterAdmin= new Command(async () => await RegisterAdminAsync());
            LoginAdmin = new Command(async () => await LoginAdminAsync());

        }

        private async Task RegisterAdminAsync()
        {
            var response = await UserService.ServiceClientInstance.RegisterAdminUser(Username, Password);

            if (response == true)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Admin User Created Sucessfully", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", " Error", "Ok");
            }
        }





        private async Task LoginAdminAsync()
        {
            var response = await UserService.ServiceClientInstance.LoginAdminUser(Username, Password);
            if(response!= null)
            {
                await SharedNav.PushModalAsync(new AdminDashboarViews());

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Wrong username or password", "ok");
            }
        }




    }
}
