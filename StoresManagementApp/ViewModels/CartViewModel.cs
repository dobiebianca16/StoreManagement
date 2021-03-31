using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using StoresManagementApp.Model;
using StoresManagementApp.Services;
using StoresManagementApp.Views;
using Xamarin.Forms;

namespace StoresManagementApp.ViewModels
{
    public class CartViewModel :BaseViewModel
    {

        public ObservableCollection<UserCartItem> CartItems { get; set; }
        private decimal _TotalCost;
        public decimal TotalCost
        {
            set
            {
                _TotalCost= value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalCost;
            }
        }
        public Command PlaceOrdersCommand { get; set; }
        public CartViewModel()
        {
            CartItems = new ObservableCollection<UserCartItem>();
            LoadItems();
            PlaceOrdersCommand = new Command(async () => await PlaceOrderAsync());
        }

        private async Task PlaceOrderAsync()
        {
            var id = await new OrderService().PlaceOrderAsync()as string ;
            RemoveItemsFromCart();
            await Application.Current.MainPage.Navigation.PushModalAsync(new OrdersView(id));
        }

        private void RemoveItemsFromCart()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
        }

        private void LoadItems()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var items = cn.Table<CartItem>().ToList();
            CartItems.Clear();
            foreach(var item in items)
            {
                CartItems.Add(new UserCartItem()
                {
                    CartItemId = item.CartId,
                    ProductId = item.ProductId,
                    ProductName=item.ProductName,
                    Price=item.Price,
                    Quantity=item.Quantity,
                    Cost=item.Price * item.Quantity
                    
                    
                }) ;
               TotalCost += (item.Price * item.Quantity);
            }
        }
    }
}
