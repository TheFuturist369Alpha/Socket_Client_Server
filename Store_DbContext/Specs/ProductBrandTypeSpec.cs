using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using App_Core.Domains.Entities;

namespace Utilities.Classes
{
    public class ProductBrandTypeSpec:BaseSpecification<Product>
    {
        public ProductBrandTypeSpec() {

            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);

        }
    }
}
