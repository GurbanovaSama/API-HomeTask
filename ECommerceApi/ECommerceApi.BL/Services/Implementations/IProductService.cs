using ECommerceApi.BL.DTOs.ProductDtos;
using ECommerceApi.Core.Entities;

namespace ECommerceApi.BL.Services.Implementations
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetALLAsync();
        Task<Product> CreateAsync(ProductCreateDto entityDto);
        Task<Product> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ProductCreateDto entityDto);
    }
}
