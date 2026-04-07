using EcommerceMvcApp.Models;

namespace EcommerceMvcApp.Services
{
    public class ProductRepository
    {
        private readonly List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 18000 },
            new Product { Id = 2, Name = "Phone", Price = 9000 },
            new Product { Id = 3, Name = "Tablet", Price = 5500 }
        };

        public IEnumerable<Product> GetAll() => products;
        public Product? GetById(int id) => products.FirstOrDefault(p => p.Id == id);
    }
}