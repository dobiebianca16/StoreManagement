using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using StoresManagementApp.Services;
using Xamarin.Forms;
using StoresManagementApp.Views;

using StoresManagementApp.ViewModels;
using StoresManagementApp.Model;
using System.Windows.Input;

namespace StoresManagementApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
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

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }

        public ICommand LoginCommand { get; set; }
        public Command RegisterCommand{ get; set; }
        public INavigation Navigation { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand= new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Succes", "User Registered", "Ok");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User Already exists ", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var Result = await UserService.ServiceClientInstance.LoginUser(Username, Password);

                if (Result != null)
                {
                    Preferences.Set("Username", Username);
                    await Navigation.PushModalAsync(new DashBoardView(Result.UserId.ToString()));
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        
    }
}
