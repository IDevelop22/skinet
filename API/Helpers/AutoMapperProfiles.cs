using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    internal class AutoMapperProfiles : Profile
    {
      
        
        public AutoMapperProfiles()
        {
            
            CreateMap<Product,ProductToReturnDto>()
            .ForMember(p=>p.ProductBrand,p=>p.MapFrom(p=>p.ProductBrand.Name))
            .ForMember(p=>p.ProductType,p=>p.MapFrom(p=>p.ProductType.Name))
            .ForMember(p=>p.PictureUrl,p=>p.MapFrom<CustomValueResolver>());
            

        }
    }
}