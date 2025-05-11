using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.BusinessLayer
{
    public class ProductService
    {

        private readonly ILogger<ProductService> _logger;

        private readonly ProductRepository _productRepository;
        public ProductService(ILogger<ProductService> logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            try
            {
                return _productRepository.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Repository mein issue");
            }
        }
        public Product GetProductById(int id)
        {
            try
            {
                return _productRepository.FindById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Repository mein issue");
            }
        }
        public Product GetProductByName(string name)
        {
            try
            {
                return _productRepository.FindByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception("Repository mein issue");
            }
        }
        public bool Insert(Product product)
        {
            try
            {
               return _productRepository.Save(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Repository mein issue");
            }
        }
    }
}
