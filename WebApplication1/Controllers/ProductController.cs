using Microsoft.AspNetCore.Mvc;
using WebApplication1.BusinessLayer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
        }
       

        [HttpGet(Name = "GetAllProduct")]
        public IEnumerable<Product> GetAllProduct()
        {
            try
            {
                _logger.LogInformation("Get product is getting called");
                return _productService.GetAllProduct();
            }
            catch (Exception ex)
            {
                throw new Exception("kuch toh hua Controller mein");
            }
        }

        [HttpGet("{id:int}")]
        public Product GetProductById(int id)
        {
            try
            {
                _logger.LogInformation("Get product is getting called");
                return _productService.GetProductById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("kuch toh hua Controller mein");
            }
        }

        [HttpGet("byname/")]
        public Product GetProductByName(string Name)
        {
            try
            {
                _logger.LogInformation("Get product is getting called");
                return _productService.GetProductByName(Name);
            }
            catch (Exception ex)
            {
                throw new Exception("kuch toh hua Controller mein");
            }
        }


        [HttpPost(Name = "Insert")]
        public bool Insert(Product product)
        {
            try
            {
                _logger.LogInformation("Get product is getting called");
                return _productService.Insert(product);
            }
            catch (Exception ex)
            {
                throw new Exception("kuch toh hua Controller mein");
            }
        }
    }
}
