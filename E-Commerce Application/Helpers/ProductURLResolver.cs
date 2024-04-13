using AutoMapper;
using App_Core.DTOs;
using App_Core.Domains.Entities;
namespace E_Commerce_Application.Helpers
{
    public class ProductURLResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;
        public ProductURLResolver(IConfiguration config)
        {
            _configuration = config;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PicrureURL))
            {
                return _configuration["APIURL"]+source.PicrureURL;
            }
            return null;
            
        }
    }
}
