using System;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using StoresManagementApp.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StoresManagementApp.Services
{
    public class OrderService
    {
        FirebaseClient client;

        public OrderService()
        {
            client = new FirebaseClient("https://storemanagement-82a44-default-rtdb.firebaseio.com/");
        }

        





        public async Task<string> PlaceOrderAsync()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<CartItem>().ToList();
            var orderid = Guid.NewGuid().ToString();
            var uname = Preferences.Get("Username", "Guest");
            decimal totalcost = 0;

            foreach(var item in data)
            {
                OrderDetails od = new OrderDetails()
                {
                    OrderId = orderid,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductId = item.ProductId,

                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity


                };
                totalcost += item.Price * item.Quantity;
                await client.Child("OrderDetail").PostAsync(od);
            }
            await client.Child("Orders").PostAsync(
                new Order()
                {
                    OrderId = orderid,
                    Username = uname,
                    TotalCost = totalcost
                });
            return orderid;
        }
    }
}
