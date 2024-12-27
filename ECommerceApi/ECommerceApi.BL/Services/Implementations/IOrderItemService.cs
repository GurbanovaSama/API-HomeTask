using ECommerceApi.BL.DTOs.OrderItemDtos;
using ECommerceApi.BL.DTOs.ProductDtos;
using ECommerceApi.Core.Entities;

namespace ECommerceApi.BL.Services.Implementations
{
    public interface IOrderItemService
    {
        Task<ICollection<OrderItem>> GetALLAsync();
        Task<OrderItem> CreateAsync(OrderItemCreateDto entityDto);
        Task<OrderItem> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, OrderItemCreateDto entityDto);
    }
}
