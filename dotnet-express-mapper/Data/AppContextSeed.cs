using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_express_mapper.Models;

namespace dotnet_express_mapper.Data
{
    public class AppContextSeed
    {
        public async Task SeedAsync(AppDbContext context)
        {
            await context.ProductTypes.AddRangeAsync(GetPreconfiguredProductTypes());
            await context.ProductBrands.AddRangeAsync(GetPreconfiguredProductBrands());
            await context.Products.AddRangeAsync(GetPreconfiguredProducts());
            await context.SaveChangesAsync();
        }

        private IEnumerable<ProductBrand> GetPreconfiguredProductBrands()
        {
            return new List<ProductBrand>
            {
                new ProductBrand { Brand = "Nike"},
                new ProductBrand { Brand = "Adidas" },
                new ProductBrand { Brand = "Puma" },
                new ProductBrand { Brand = "Uniqlo" },
                new ProductBrand { Brand = "Other" }
            };
        }

        private IEnumerable<ProductType> GetPreconfiguredProductTypes()
        {
            return new List<ProductType>
            {
                new ProductType { Type = "Shoes"},
                new ProductType { Type = "T-Shirt" },
                new ProductType { Type = "Paint" }
            };
        }

        private IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product { ProductTypeId = 2, ProductBrandId = 1, AvailableStock = 100, Description = "Black Hoodie", Name = "Bot Black Hoodie", Price = 19.5M },
                new Product { ProductTypeId = 1, ProductBrandId = 2, AvailableStock = 100, Description = "Black & White Shoes", Name = "Black & White Shoes", Price= 8.50M },
                new Product { ProductTypeId = 2, ProductBrandId = 5, AvailableStock = 100, Description = "Prism White T-Shirt", Name = "Prism White T-Shirt", Price = 12 },
                new Product { ProductTypeId = 2, ProductBrandId = 3, AvailableStock = 100, Description = "Foundation T-shirt", Name = ".Foundation T-shirt", Price = 12 },
                new Product { ProductTypeId = 3, ProductBrandId = 4, AvailableStock = 100, Description = "Roslyn Red trousers pants", Name = "Roslyn Red trousers pants", Price = 8.5M},
                new Product { ProductTypeId = 2, ProductBrandId = 2, AvailableStock = 100, Description = "Blue Hoodie", Name = " Blue Hoodie", Price = 12 },
                new Product { ProductTypeId = 2, ProductBrandId = 5, AvailableStock = 100, Description = "Roslyn Red T-Shirt", Name = "Roslyn Red T-Shirt", Price = 12 },
                new Product { ProductTypeId = 2, ProductBrandId = 1, AvailableStock = 100, Description = "Kudu Purple Hoodie", Name = "Kudu Purple Hoodie", Price = 8.5M },
                new Product { ProductTypeId = 1, ProductBrandId = 5, AvailableStock = 100, Description = "White Sneaker", Name = "White Sneaker 11", Price = 12 },
                new Product { ProductTypeId = 3, ProductBrandId = 3, AvailableStock = 100, Description = "F1 Trouser", Name = "F1 trousers pants", Price = 11 },
                new Product { ProductTypeId = 3, ProductBrandId = 2, AvailableStock = 100, Description = "Trouser", Name = " Trouser 11", Price = 8.50M },
                new Product { ProductTypeId = 2, ProductBrandId = 4, AvailableStock = 100, Description = "Prism White TShirt", Name = "Prism White TShirt", Price = 16 }
            };
        }
    }
}