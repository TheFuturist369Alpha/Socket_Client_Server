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
        public ProductBrandTypeSpec(string? sort, Guid? brandId, Guid? typeId) 
            : base(x=>(!brandId.HasValue ||
            x.ProductBrandId==brandId)&&(!typeId.HasValue||x.ProductTypeId==typeId)) {

            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
            SetOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        SetOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        SetOrderByDesc(x => x.Price);
                        break;

                    default:
                        SetOrderBy(x => x.Description);
                        break;
                }
            }

        }

        public ProductBrandTypeSpec(Guid Id):base(x=>x.Id==Id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand); 
        }
    }
}
