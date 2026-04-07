using EcommerceMvcApp.Models;
using EcommerceMvcApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMvcApp.Controllers
{
    public class StoreController : Controller
    {
        private readonly ProductRepository _repo;
        private readonly OrderService _orderService;
        private readonly CartService _cartService;

        // Inject the services into the controller
        public StoreController(ProductRepository repo, OrderService orderService, CartService cartService)
        {
            _repo = repo;
            _orderService = orderService;
            _cartService = cartService;
        }

        // Equivalent to Option 1: List Products
        public IActionResult Index()
        {
            var products = _repo.GetAll();
            return View(products);
        }

        // Equivalent to Option 2: Add Product to Cart
        [HttpPost]
        public IActionResult AddToCart(int prodId)
        {
            var product = _repo.GetById(prodId);
            if (product != null)
            {
                var cartItem = _cartService.Cart.FirstOrDefault(c => c.Product.Id == prodId);
                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    _cartService.Cart.Add(new CartItem { Product = product, Quantity = 1 });
                }
            }
            return RedirectToAction("Index"); // Send them back to the product list
        }

        // Equivalent to Option 3: View Cart
        public IActionResult Cart()
        {
            return View(_cartService.Cart);
        }

        // Equivalent to Option 4: Checkout
        [HttpPost]
        public IActionResult Checkout()
        {
            if (!_cartService.Cart.Any())
            {
                TempData["Message"] = "Cart is empty. Add items first.";
                return RedirectToAction("Cart");
            }

            var order = new Order { Items = new List<CartItem>(_cartService.Cart) };
            _orderService.PlaceOrder(order);
            _cartService.ClearCart();

            return RedirectToAction("OrderSuccess");
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}
