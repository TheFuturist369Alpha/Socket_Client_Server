using App_Core.Domains.Repo_Contracts;
using App_Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repo;
        public ProductsController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("product get/{Id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(Guid Id)
        {
            if (Id != null)
                return (await _repo.GetProductById(Id)).ToProductDTO();
            return BadRequest();
        }

        [HttpPost("Add product")]
        public async Task<ActionResult> AddProduct(ProductDTO product)
        {
            await _repo.AddProduct(product.ToProduct());
            return Ok(product); 
        }
    }
}
