using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using StoresManagementApp.Model;
using StoresManagementApp.Services;
using StoresManagementApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace StoresManagementApp.ViewModels
{
    public class SubcategoryViewModel : BaseViewModel
    {

        private string _Username;
        public string Username
        {
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
            get
            {
                return _Username;
            }
        }

        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserCartItemsCount;
            }
        }

        private string _SearchText;

        public string SearchText
        {
            set
            {
                _SearchText = value;
                OnPropertyChanged();
            }
            get
            {
                return _SearchText;
            }
        }

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

        public Command SearchViewCommand { get; set; }

        public ObservableCollection<Category> Categories { get; set; }
      
        public Command ViewCartCommand { get; set; }

        public Command OrdersHistoryCommand { get; set; }

        public Command LogoutCommand { get; set; }

        public Command DashBoardCommand { get; set; }
        

        public  SubcategoryViewModel()
        {
            Categories = new ObservableCollection<Category>();
            GetCategories();

            var uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
                Username = "Guest";
            else
                Username = uname;
            UserCartItemsCount = new CartItemService().GetUserCartCount();

            
            ViewCartCommand= new Command(async () => await ViewCartAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());
            GetCategories();

            OrdersHistoryCommand = new Command(async () => await OrdersHistoryAsync());

            SearchViewCommand= new Command(async () => await SearchViewAsync());

 
        }

       
        private async Task SearchViewAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SearchResultsView(SearchText));
        }

        private async Task OrdersHistoryAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new OrderHistoryView());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async Task LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        private async void GetCategories()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }
       

    }
}
