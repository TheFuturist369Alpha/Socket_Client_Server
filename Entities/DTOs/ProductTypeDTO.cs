using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Core.DTOs
{
    public class ProductTypeDTO
    {
        [Required(ErrorMessage = "Product type required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "String too long or too short")]
        public string Name { get; set; }
    }
}
