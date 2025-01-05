using AutoMapper;
using FinalApiTask.BL.DTOs.ProductDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Profiles.ProductProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<ProductEditDto, Product>().ReverseMap();  
        }
    }
}
