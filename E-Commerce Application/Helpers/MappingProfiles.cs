using AutoMapper;
using App_Core.DTOs;
using App_Core.Domains.Entities;

namespace E_Commerce_Application.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() {
            CreateMap<Product, ProductDTO>().ForMember(d => d.PicrureURL, o => o.MapFrom<ProductURLResolver>());
        
        }
    }
}
