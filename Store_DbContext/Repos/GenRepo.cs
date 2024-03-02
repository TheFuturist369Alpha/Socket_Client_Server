using App_Core.Domains.Entities;
using App_Core.Domains.Repo_Contracts;
using App_Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Infrastructure.Repos
{
    public class GenRepo<T> : IGenRepos<T> where T : class
    {
        private readonly StoreDbContext _dbContext;
        public GenRepo(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddProduct(T product)
        {
            if (product == null)
                throw new ArgumentNullException();
            await _dbContext.Set<T>().AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductById(Guid id)
        {
            T? p1 = await _dbContext.Set<T>().FindAsync(id);
            if (p1 == null)
                throw new ArgumentException();
            _dbContext.Set<T>().Remove(p1);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetProductById(Guid id)
        {
            T? p1 = await _dbContext.Set<T>().FindAsync(id);
            if (p1 == null)
                throw new ArgumentException();
            return p1;

        }

        public async Task<IReadOnlyList<T>> GetProducts()
        {
            if (_dbContext.products == null || await _dbContext.Set<T>().CountAsync() == 0)
                return null;
            return await _dbContext.Set<T>().ToListAsync();
        }

        public Task UpdateProduct(T product)
        {
            throw new NotImplementedException();
        }
    }
}
