using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPryaniky.Controllers;
using WebApiPryaniky.Data;
using WebApiPryaniky.Models;
using Xunit;

namespace WebApiPryaniky.Tests
{
    public class ProductsControllerTests
    {
        private readonly List<Product> products = new List<Product>() { new() { Id = 1, Name = "product1", Cost = 1 }, new() { Id = 2, Name = "product2", Cost = 2 } };

        [Fact]
        public async Task Get_ListProducts_ReturnedProductsId()
        {
            //Arrange
            var repos = new Mock<IProductRepository>();
            repos.Setup(r => r.GetProducts()).Returns(Task.Run(() => products));
            var controller = new ProductsController(repos.Object);

            //Act
            var returnedProducts = (await controller.Get()).ToList();

            //Assert
            Assert.Equal(products[0].Id, returnedProducts[0].Id);
            Assert.Equal(products[1].Id, returnedProducts[1].Id);
        }

        [Fact]
        public async Task Post_NewProduct_ProductsCount()
        {
            //Arrange
            var repos = new Mock<IProductRepository>();
            repos.Setup(r => r.AddProduct(It.IsAny<Product>())).Returns(Task.Run(() => products.Add(new ())));
            var controller = new ProductsController(repos.Object);

            //Act
            await controller.Post(null);

            //Assert
            Assert.Equal(3, products.Count);
        }

        [Fact]
        public async Task Delete_NewProduct_ProductsCountAndRemainingProductId()
        {
            //Arrange
            var repos = new Mock<IProductRepository>();
            repos.Setup(r => r.RemoveProduct(1)).Returns(Task.Run(() => products.RemoveAt(0)));
            var controller = new ProductsController(repos.Object);

            //Act
            await controller.Post(null);

            //Assert
            Assert.Equal(1, products.Count);
            Assert.Equal(2, products[0].Id);
        }
    }
}
