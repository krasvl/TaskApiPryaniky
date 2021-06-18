using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPryaniky.Models;

namespace WebApiPryaniky.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>() { new() { Id = 1, Name = "product1", Cost = 1 }, new() { Id = 2, Name = "product2", Cost = 2 } };

        public async Task AddProduct(Product product)
        {
            await Task.Run(() => products.Add(product));
        }

        public async Task<List<Product>> GetProducts()
        {
            return await Task.Run(() => products);
        }

        public async Task RemoveProduct(int id)
        {
            await Task.Run(() => products.Remove(products.FirstOrDefault(p => p.Id == id)));
        }
    }
}
