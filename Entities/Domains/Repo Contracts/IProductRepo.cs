using App_Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Core.Domains.Repo_Contracts
{
    public interface IProductRepo
    {
        public Task AddProduct(Product product);
        public Task<IReadOnlyList<Product>> GetProducts();
        public Task<Product> GetProductById(Guid id);
        public Task UpdateProduct(Product product);
        public Task DeleteProductById(Guid id);
        public Task<IReadOnlyList<ProductBrand>> GetBrands();
        public Task<IReadOnlyList<ProductType>> GetTypes();
    }
}
