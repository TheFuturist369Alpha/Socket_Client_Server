using App_Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Core.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage ="Product name required.")]
        [StringLength(100, MinimumLength=3, ErrorMessage ="String too long or too short")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price required.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Description required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description too long or too short")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Picture required.")]
        public string PicrureURL { get; set; }
        public ProductType? ProductType { get; set; }
        public ProductBrand? ProductBrand { get; set; }

        public Product ToProduct()
        {
            return new Product()
            {
                Id = new Guid(),
                Name = Name,
                Price = Price,
                Description = Description,
                PicrureURL = PicrureURL,
                ProductBrandId = new Guid(),
                ProductTypeId = new Guid()

            };
        }
      
    }
}
