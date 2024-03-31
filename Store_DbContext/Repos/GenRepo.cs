using App_Core.Domains.Entities;
using App_Core.Domains.Other_Contracts;
using App_Core.Domains.Repo_Contracts;
using App_Infrastructure.Data;
using App_Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Infrastructure.Repos
{
    public class GenRepo<T> : IGenRepos<T> where T:class
    {
        private readonly StoreDbContext _dbContext;
        public GenRepo(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task<T> GetEntityWithSpec(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }
    }
}
