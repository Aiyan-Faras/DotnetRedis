using System.Threading;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.CacheService;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.BusinessLayer
{
    public class ProductService
    {

        private readonly ILogger<ProductService> _logger;

        private readonly ProductRepository _productRepository;
        private readonly ProductCacheService _productCacheService;
        public ProductService(ILogger<ProductService> logger, ProductRepository productRepository, ProductCacheService productCacheService)
        {
            _logger = logger;
            _productRepository = productRepository;
            _productCacheService = productCacheService;
        }

        public async Task<IEnumerable<Product>> GetAllProduct(CancellationToken token)
        {
            try
            {
                return await _productCacheService.GetAllAsync(() => Task.FromResult(_productRepository.FindAll()), token);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Repository mein issue"+ ex.Message);
            }
        }
        
        public async Task<Product> GetProductByName(string name, CancellationToken token)
        {
            try
            {
                return await _productCacheService.GetByNameAsync(name, () => Task.FromResult(_productRepository.FindByName(name)), token) ?? default!;
            }
            catch (Exception ex)
            {
                throw new Exception("Repository mein issue" + ex.Message);
            }
        }

        public async Task<bool> UpdateProductAsync(Product product, CancellationToken token = default)
        {
            try
            {
                var updated = _productRepository.Save(product);
                if (updated)
                {
                    await _productCacheService.SetAsync(product, token); // update cache
                }
                return updated;
            }
            catch (Exception ex)
            {
                throw new Exception("Repository mein issue " + ex.Message);
            }
        }
        public async Task<bool> Insert(Product product, CancellationToken token)
        {
            try
            {
                await _productCacheService.SetAsync(product, token);
                return await Task.FromResult(_productRepository.Save(product));
            }
            catch (Exception ex)
            {
                throw new Exception("Repository mein issue " + ex.Message);
            }
        }

        public async Task<bool> RemoveProductAsync(string name, CancellationToken token = default)
        {
            try
            {
                var removed = _productRepository.Remove(name);
                if (removed)
                {
                    await _productCacheService.RemoveAsync(name, token); // remove from cache
                }
                return removed;
            }
            catch (Exception ex)
            {
                throw new Exception("Repository mein issue " + ex.Message);
            }
        }
    }
}
