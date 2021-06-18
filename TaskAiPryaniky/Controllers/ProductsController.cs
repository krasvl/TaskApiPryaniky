using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPryaniky.Data;
using WebApiPryaniky.Models;

namespace WebApiPryaniky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await productRepository.GetProducts();
        }

        [HttpPost("{product}")]
        public async Task Post(Product product)
        {
            await productRepository.AddProduct(product);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await productRepository.RemoveProduct(id);
        }
    }
}
