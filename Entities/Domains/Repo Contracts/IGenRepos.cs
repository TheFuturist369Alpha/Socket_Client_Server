using App_Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Core.Domains.Repo_Contracts
{
    public interface IGenRepos<T>
    {
        public Task AddProduct(T product);
        public Task<IReadOnlyList<T>> GetProducts();
        public Task<T> GetProductById(Guid id);
        public Task UpdateProduct(T product);
        public Task DeleteProductById(Guid id);
    }
}
