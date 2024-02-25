using App_Core.DTOs;

namespace App_Core.Domains.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PicrureURL { get; set; }
        public ProductType ProductType { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductBrandId { get; set; }

        public ProductDTO ToProductDTO()
        {
            return new ProductDTO()
            {

                Name = Name,
                Price = Price,
                Description = Description,
                PicrureURL = PicrureURL,
                ProductBrand = ProductBrand,
                ProductType = ProductType


            };
        }

    }
}