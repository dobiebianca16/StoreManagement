using System;
using System.Collections.ObjectModel;
using StoresManagementApp.Model;
using StoresManagementApp.Services;
using Xamarin.Forms;

namespace StoresManagementApp.ViewModels
{
    public class OrderHistoryViewModel: BaseViewModel
    {
        public ObservableCollection<OrdersHistory> OrderDetails { get; set; }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
               _IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return _IsBusy;
            }
        }

        public OrderHistoryViewModel()
        {

            OrderDetails = new ObservableCollection<OrdersHistory>();
            LoadUserOrders();

        }

        private async void LoadUserOrders()
        {
            try
            {
                IsBusy = true;
                OrderDetails.Clear();
                var service = new OrderHistoryService();
                var details = await service.GetOrderDetailsAsync();
                foreach(var order in details)
                {
                    OrderDetails.Add(order);
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("error", ex.Message, "ok");
            }
            finally
            {
                IsBusy = true;
            }
        }
    }
}
