using AutoMapper;
using ECommerceApi.BL.DTOs.OrderItemDtos;
using ECommerceApi.Core.Entities;

namespace ECommerceApi.BL.Profiles.OrderItemProfiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItemCreateDto, OrderItem>();
            CreateMap<OrderItemCreateDto, OrderItem>().ReverseMap();
        }
    }
}
