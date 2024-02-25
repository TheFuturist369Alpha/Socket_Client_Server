using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Core.Domains.Entities;
using App_Core.Domains.Repo_Contracts;
using App_Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace App_Infrastructure.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly StoreDbContext _dbContext;
        public ProductRepo(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();
           await _dbContext.products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

           
        }

        public async Task DeleteProductById(Guid id)
        {
            Product? p1 = await _dbContext.products.FindAsync(id);
            if (p1 == null)
                throw new ArgumentException();
            _dbContext.products.Remove(p1);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetBrands()
        {
            return await _dbContext.brands.ToListAsync();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            Product? p1 = await _dbContext.products
                .Include(p => p.ProductBrand).Include(p => p.ProductType).FirstOrDefaultAsync(obj=>obj.Id==id);
            if (p1 == null)
                throw new ArgumentException();
           return p1;
            
        }

        public async Task<IReadOnlyList<Product>?> GetProducts()
        {
            if (_dbContext.products == null || await _dbContext.products.CountAsync() == 0)
                return null;
            return await _dbContext.products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)
                .ToListAsync();
                
               
        }

        public async Task<IReadOnlyList<ProductType>> GetTypes()
        {
           return await _dbContext.types.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
