using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StoresManagementApp.Model
{
    public class Product
    {
        public string CategoryName { get; set; }
        public string SubcategoryName { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public ImageSource Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        
    }

}
