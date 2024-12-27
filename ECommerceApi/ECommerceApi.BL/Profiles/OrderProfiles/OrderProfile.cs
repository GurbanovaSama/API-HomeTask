using AutoMapper;
using ECommerceApi.BL.DTOs.OrderDtos;
using ECommerceApi.Core.Entities;

namespace ECommerceApi.BL.Profiles.OrderProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderCreateDto, Order>().ReverseMap();
        }
    }
}
