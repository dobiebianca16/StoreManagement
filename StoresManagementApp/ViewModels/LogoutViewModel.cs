using System;
using System.Threading.Tasks;
using StoresManagementApp.Services;
using StoresManagementApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoresManagementApp.ViewModels
{
    public class LogoutViewModel: BaseViewModel
    {
        private string _UserId;

        public string UserId
        {
            set
            {
                _UserId = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserId;
            }
        }
        public Command LogoutCommand { get; set; }
        public Command GoToMeniu { get; set; }

        public LogoutViewModel()
        {
            LogoutCommand = new Command (async () =>  await LogoutUserAsync());
            GoToMeniu = new Command(async () =>  await GoToMeniuAsync());
        }

        private async Task GoToMeniuAsync()
        {

            await Application.Current.MainPage.Navigation.PushModalAsync(new SubcategoriesView());
        }

        private async Task LogoutUserAsync()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
            Preferences.Remove("Username");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
        }
    }
}
