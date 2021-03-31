using System;
using System.Collections.Generic;

namespace StoresManagementApp.Model
{
    public class Cart
    {
        public string Username { get; set; }
        public int CartId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
