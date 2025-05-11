using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public  class ProductRepository
    {
       private static readonly List<Product> _products = new List<Product>
    {
        new Product { ProductId = 1, Name = "C# Unleashed", Description = "Comprehensive guide to C#", Price = 49.99, DateCreated = DateTime.Now.AddDays(-30), DateModified = DateTime.Now.AddDays(-5) },
        new Product { ProductId = 2, Name = "ASP.NET Core in Action", Description = "Build web apps with ASP.NET Core", Price = 59.99, DateCreated = DateTime.Now.AddDays(-25), DateModified = DateTime.Now.AddDays(-2) },
        new Product { ProductId = 3, Name = "Entity Framework Core Cookbook", Description = "Recipes for EF Core", Price = 39.50, DateCreated = DateTime.Now.AddDays(-20), DateModified = DateTime.Now.AddDays(-1) },
        new Product { ProductId = 4, Name = "Pro LINQ", Description = "LINQ best practices", Price = 28.99, DateCreated = DateTime.Now.AddDays(-15), DateModified = DateTime.Now.AddDays(-1) },
        new Product { ProductId = 5, Name = "Clean Code", Description = "A Handbook of Agile Software Craftsmanship", Price = 45.00, DateCreated = DateTime.Now.AddDays(-12), DateModified = DateTime.Now.AddDays(-1) },
        new Product { ProductId = 6, Name = "Design Patterns", Description = "Elements of Reusable Object-Oriented Software", Price = 55.00, DateCreated = DateTime.Now.AddDays(-10), DateModified = DateTime.Now.AddDays(-1) },
        new Product { ProductId = 7, Name = "The Pragmatic Programmer", Description = "Your Journey to Mastery", Price = 42.00, DateCreated = DateTime.Now.AddDays(-8), DateModified = DateTime.Now.AddDays(-1) },
        new Product { ProductId = 8, Name = "Refactoring", Description = "Improving the Design of Existing Code", Price = 38.75, DateCreated = DateTime.Now.AddDays(-6), DateModified = DateTime.Now.AddDays(-1) },
        new Product { ProductId = 9, Name = "Head First Design Patterns", Description = "A Brain-Friendly Guide", Price = 35.20, DateCreated = DateTime.Now.AddDays(-4), DateModified = DateTime.Now.AddDays(-1) },
        new Product { ProductId = 10, Name = "Effective C#", Description = "50 Specific Ways to Improve Your C#", Price = 29.95, DateCreated = DateTime.Now.AddDays(-2), DateModified = DateTime.Now },
        new Product { ProductId = 11, Name = "C# Unleashed", Description = "Short description here", Price = 49.99, DateCreated = DateTime.Now, DateModified = DateTime.Now },
        new Product { ProductId = 12, Name = "ASP.Net Unleashed", Description = "Short description here", Price = 59.99, DateCreated = DateTime.Now, DateModified = DateTime.Now },
        new Product { ProductId = 13, Name = "Silverlight Unleashed", Description = "Short description here", Price = 29.99, DateCreated = DateTime.Now, DateModified = DateTime.Now }

    };

        public IEnumerable<Product> FindAll() => _products;
        public Product FindByName(string name) => _products.FirstOrDefault(p => p.Name == name) ?? default!;
        public bool Remove(string name)
        {
            var itemToRemove = _products.SingleOrDefault(r => r.Name == name);
            var res = false;
            if (itemToRemove != null)
                res = _products.Remove(itemToRemove);
            return res;
        }

        public bool Save(Product product)
        {
            if (product.ProductId == 0)
            {
                product.ProductId = _products.Max(p => p.ProductId) + 1;
                product.DateCreated = product.DateModified = DateTime.Now;
                _products.Add(product);
                return true;
            }
            var existing = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existing == null) return false;
            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.DateModified = DateTime.Now;
            return true;
        }
    }
}
