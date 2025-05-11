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
        public async Task<IEnumerable<Product>> GetAllProduct( CancellationToken token)
        {
            try
            {
                _logger.LogInformation("Get product is getting called");
                return await _productService.GetAllProduct(token);
            }
            catch (Exception ex)
            {
                throw new Exception("kuch toh hua Controller mein "+ ex.Message);
            }
        }

        

        [HttpGet("byname/")]
        public async Task<Product> GetProductByName(string Name, CancellationToken token)
        {
            try
            {
                _logger.LogInformation("Get product is getting called");
                return await _productService.GetProductByName(Name, token);
            }
            catch (Exception ex)
            {
                throw new Exception("kuch toh hua Controller mein " + ex.Message);
            }
        }


        [HttpPost(Name = "Insert")]
        public async Task<bool> Insert(Product product, CancellationToken token)
        {
            try
            {
                _logger.LogInformation("Get product is getting called");
                return await _productService.Insert(product, token);
            }
            catch (Exception ex)
            {
                throw new Exception("kuch toh hua Controller mein " + ex.Message);
            }
        }
        [HttpPut]
        public async Task<bool> Update(Product product, CancellationToken token)
        {
            try
            {
                _logger.LogInformation("Get product is getting called");
                return await _productService.UpdateProductAsync(product, token);
            }
            catch (Exception ex)
            {
                throw new Exception("kuch toh hua Controller mein " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<bool> Delete(string name, CancellationToken token)
        {
            try
            {
                _logger.LogInformation("Get product is getting called");
                return await _productService.RemoveProductAsync(name, token);
            }
            catch (Exception ex)
            {
                throw new Exception("kuch toh hua Controller mein " + ex.Message);
            }
        }

    }
}
