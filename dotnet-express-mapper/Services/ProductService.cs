using dotnet_express_mapper.Models;
using dotnet_express_mapper.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace dotnet_express_mapper.Services
{
    public class ProductService
    {
        private readonly AppDbContext _appDBContext;

        public ProductService(AppDbContext context)
        {
            _appDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _appDBContext.Products.Include(a => a.ProductType).Include(a => a.ProductBrand).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _appDBContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Create(Product product)
        {
            await _appDBContext.Products.AddAsync(product);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product productIn)
        {
            var productItem = await _appDBContext.Products.SingleOrDefaultAsync(i => i.Id == productIn.Id);
            productItem = productIn;

            _appDBContext.Products.Update(productItem);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _appDBContext.Products.SingleOrDefaultAsync(i => i.Id == id);

            if (product == null)
            {
                return false;
            }

            _appDBContext.Products.Remove(product);
            await _appDBContext.SaveChangesAsync();

            return true;
        }

        public async Task<ActionResult<List<ProductBrand>>> ProductBrandsAsync()
        {
            return await _appDBContext.ProductBrands.ToListAsync();
        }
    }
}