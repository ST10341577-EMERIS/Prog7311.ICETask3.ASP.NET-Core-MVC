using System.Collections.Generic;
using System.Linq;

namespace EcommerceMvcApp.Models
{
    public class Order
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal Total => Items.Sum(i => i.TotalPrice);
    }
}