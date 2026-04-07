using EcommerceMvcApp.Models;

namespace EcommerceMvcApp.Services
{
    public class OrderService
    {
        private readonly List<Order> orders = new List<Order>();

        public void PlaceOrder(Order order)
        {
            orders.Add(order);
        }
        public IEnumerable<Order> GetAllOrders() => orders;
    }
}