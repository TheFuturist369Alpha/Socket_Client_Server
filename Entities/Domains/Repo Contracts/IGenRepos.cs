using App_Core.Domains.Entities;
using App_Core.Domains.Other_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Classes;

namespace App_Core.Domains.Repo_Contracts
{
    public interface IGenRepos<T> where T:BaseEntity
    {
        public Task<T> GetByIdAsync(Guid id);
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<T> GetEntityWithSpec(ISpecification<T> specification);
        public Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
