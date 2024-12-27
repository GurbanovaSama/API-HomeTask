using ECommerceApi.BL.DTOs.OrderDtos;
using ECommerceApi.BL.DTOs.ProductDtos;
using ECommerceApi.Core.Entities;

namespace ECommerceApi.BL.Services.Implementations
{
    public interface IOrderService
    {
        Task<ICollection<Order>> GetALLAsync();
        Task<Order> CreateAsync(OrderCreateDto entityDto);
        Task<Order> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, OrderCreateDto entityDto);
    }
}
