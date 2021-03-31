using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using StoresManagementApp.Model;
using Xamarin.Essentials;

namespace StoresManagementApp.Services
{
    public class OrderHistoryService
    {
        FirebaseClient client;
        List<OrdersHistory> UserOrder;

        public OrderHistoryService()
        {
            client = new FirebaseClient("https://storemanagement-82a44-default-rtdb.firebaseio.com/");
            UserOrder = new List<OrdersHistory>();
        }
        public async Task<List<OrdersHistory>> GetOrderDetailsAsync()
        {
            var uname = Preferences.Get("Username", "Guest");
            var orders = (await client.Child("Orders")
                .OnceAsync<Order>())
                .Where(o => o.Object.Username.Equals(uname))
                .Select(o => new Order()
                {
                    OrderId = o.Object.OrderId,
                    TotalCost = o.Object.TotalCost,



                }).ToList();
            foreach (var order in orders)
            {
                OrdersHistory oh = new OrdersHistory();

                oh.OrderId = order.OrderId;

                oh.TotalCost = order.TotalCost;


                var orderDetails = (await client.Child("OrderDetails")
                    .OnceAsync<OrderDetails>())
                    .Where(o => o.Object.OrderId.Equals(order.OrderId))
                    .Select(o => new OrderDetails()
                    {
                        OrderId = o.Object.OrderId,
                        OrderDetailId = o.Object.OrderDetailId,
                        ProductId = o.Object.ProductId,
                        ProductName = o.Object.ProductName,
                        Quantity = o.Object.Quantity,
                        Price = o.Object.Price

                    }).ToList();
                oh.AddRange(orderDetails);
                UserOrder.Add(oh);

            }
            return UserOrder;
        }
    }
}
