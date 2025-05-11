using Microsoft.Extensions.Caching.Hybrid;
using WebApplication1.Models;

namespace WebApplication1.CacheService
{
    public class ProductCacheService
    {
        private readonly HybridCache _hybridCache;
        private const string ProductKeyPrefix = "product:";
        public ProductCacheService(HybridCache hybridCache)
        {
            _hybridCache = hybridCache;
        }

        public async Task<Product?> GetByNameAsync(string name, Func<Task<Product?>> fetchFromDb, CancellationToken token = default)
        {
            string cacheKey = $"{ProductKeyPrefix}{name}";
            return await _hybridCache.GetOrCreateAsync(
                cacheKey,
                async _ => await fetchFromDb(),
                cancellationToken: token
            );
        }
        public async Task<IEnumerable<Product?>> GetAllAsync(Func<Task<IEnumerable<Product?>>> fetchFromDb, CancellationToken token = default)
        {
            string cacheKey = $"{ProductKeyPrefix}:all";
            return await _hybridCache.GetOrCreateAsync(
                cacheKey,
                async _ => await fetchFromDb(),
                cancellationToken: token
            );
        }
        public async Task SetAsync(Product product, CancellationToken token = default)
        {
            string cacheKey = $"{ProductKeyPrefix}{product.Name}";
            await _hybridCache.SetAsync(
                cacheKey,
                product,
                new HybridCacheEntryOptions
                {
                    Expiration = TimeSpan.FromMinutes(2),
                    LocalCacheExpiration = TimeSpan.FromMinutes(1)
                }
            );
        }

        public async Task RemoveAsync(string name, CancellationToken token = default)
        {
            string cacheKey = $"{ProductKeyPrefix}{name}";
            await _hybridCache.RemoveAsync(cacheKey, token);
        }

    }
}
