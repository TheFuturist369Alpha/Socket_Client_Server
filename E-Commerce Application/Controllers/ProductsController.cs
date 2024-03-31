using App_Core.Domains.Entities;
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
        private readonly IGenRepos<Product> _repo;
        private readonly IGenRepos<ProductBrand> _brandRepo;
        private readonly IGenRepos<ProductType> _typeRepo;
        public ProductsController(IGenRepos<Product> repo, 
            IGenRepos<ProductBrand> brandRepo, IGenRepos<ProductType> typeRepo)
        {
            _repo = repo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
        }

        [HttpGet("product get/{Id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(Guid Id)
        {
            if (Id != null)
                return (await _repo.GetByIdAsync(Id)).ToProductDTO();
            return BadRequest();
        }

        [HttpGet("Get products")]
        public async Task<ActionResult> GetProducts()
        {
            
            return Ok(await _repo.GetAllAsync()); 
        }

        [HttpGet]
        [Route("Get Brands")]
        public async Task<ActionResult> GetBrands()
        {
            return Ok(await _brandRepo.GetAllAsync());
        }

        [HttpGet]
        [Route("Get Types")]
        public async Task<ActionResult> GetTypes()
        {
            return Ok(await _brandRepo.GetAllAsync());
        }
    }
}
