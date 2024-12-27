using AutoMapper;
using ECommerceApi.BL.DTOs.ProductDtos;
using ECommerceApi.Core.Entities;

namespace ECommerceApi.BL.Profiles.ProductProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductCreateDto, Product>().ReverseMap();
        }
    }
}
