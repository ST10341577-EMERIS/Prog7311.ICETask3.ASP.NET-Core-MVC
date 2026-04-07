using EcommerceMvcApp.Models;

namespace EcommerceMvcApp.Services
{
    public class CartService
    {
        public List<CartItem> Cart { get; set; } = new List<CartItem>();

        public void ClearCart()
        {
            Cart.Clear();
        }
    }
}