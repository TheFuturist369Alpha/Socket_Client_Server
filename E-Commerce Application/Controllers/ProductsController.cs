using App_Core.Domains.Entities;
using App_Core.Domains.Repo_Contracts;
using App_Core.DTOs;
using AutoMapper;
using E_Commerce_Application.Errors;
using E_Commerce_Application.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities.Classes;

namespace E_Commerce_Application.Controllers
{
    
    public class ProductsController : CBaseController
    {
        private readonly IGenRepos<Product> _repo;
        private readonly IGenRepos<ProductBrand> _brandRepo;
        private readonly IGenRepos<ProductType> _typeRepo;
        private readonly IMapper _mappingProfiles;
        public ProductsController(IGenRepos<Product> repo, 
            IGenRepos<ProductBrand> brandRepo, IGenRepos<ProductType> typeRepo, IMapper mp)
        {
            _repo = repo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
            _mappingProfiles = mp;
        }

        [HttpGet("product get/{Id}")]
        [ProducesResponseType(typeof(APIResponse),StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDTO>> GetProduct(Guid Id)
        {
            if (Id == null) return BadRequest();

            var spec = new ProductBrandTypeSpec(Id);
            var product = _repo.GetEntityWithSpec(spec);
            if (product == null) return NotFound( new APIResponse(404));
            return _mappingProfiles.Map<Product, ProductDTO>(await product);

        }

        [HttpGet("Get products")]
        public async Task<ActionResult> GetProducts(string? sort, Guid? brandId, Guid? typeId)
        {
            
            return Ok((await _repo.ListAsync(new ProductBrandTypeSpec(sort,brandId,typeId))).Select(product=>product.ToProductDTO())); 
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
