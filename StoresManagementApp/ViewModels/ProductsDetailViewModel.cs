using System;
using System.Linq;
using StoresManagementApp.Model;
using StoresManagementApp.Views;
using Xamarin.Forms;

namespace StoresManagementApp.ViewModels
{
    public class ProductsDetailViewModel:BaseViewModel
    {
        private Product  _SelectedProduct;
        public Product SelectedProduct
        {
            set
            {
                _SelectedProduct = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedProduct;
            }
        }
        
        private int _TotalQuantity;
        public int TotalQuantity
        {
            set
            {
                this._TotalQuantity = value;
                if(this._TotalQuantity < 0)
          
                    this._TotalQuantity = 0;

                if (this._TotalQuantity > 10)
                    this._TotalQuantity -= 1;

                OnPropertyChanged();
            }
            get
            {
                return _TotalQuantity;
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
        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomeCommand { get; set; }


        public ProductsDetailViewModel(Product product)
        {
            SelectedProduct = product;
            TotalQuantity = 0;
            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(() => ViewCartAsync());
            HomeCommand = new Command(() => GoToHomeAsync());
        }

        private async void GoToHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SubcategoriesView());
        }

        private async void ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private void AddToCart()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                CartItem ci = new CartItem()
                {
                    ProductId = SelectedProduct.ProductId,
                    ProductName = SelectedProduct.ProductName,
                    Price = SelectedProduct.Price,
                    Quantity = TotalQuantity,
                };
                var item = cn.Table<CartItem>().ToList().FirstOrDefault(c => c.ProductId == SelectedProduct.ProductId);
                if (item == null)
                    cn.Insert(ci);
                else
                {
                    item.Quantity += TotalQuantity;
                    cn.Update(item);
                }
                cn.Commit();
                cn.Close();
                Application.Current.MainPage.DisplayAlert("Cart", "Selected item added to cart", "ok");

            }
            catch(Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
            finally
            {
                cn.Close();
            }
        }

        private void DecrementOrder()
        {
            TotalQuantity--;
        }

        private void IncrementOrder()
        {
            TotalQuantity++;
        }
    }
}
