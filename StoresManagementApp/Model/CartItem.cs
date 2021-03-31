using System;
using SQLite;

namespace StoresManagementApp.Model
{

    [Table("CartItem")]
    
    public class CartItem
    {
        [AutoIncrement,PrimaryKey]
        public int CartId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
