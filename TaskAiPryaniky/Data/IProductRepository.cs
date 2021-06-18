using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPryaniky.Models;

namespace WebApiPryaniky.Data
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task AddProduct(Product product);
        public Task RemoveProduct(int id);
    }
}
