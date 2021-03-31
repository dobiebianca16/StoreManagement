using System;
namespace StoresManagementApp.Model
{
    public class OrderDetails
    {
        public string OrderDetailId { get; set; }

        public string OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
      
    }
}
