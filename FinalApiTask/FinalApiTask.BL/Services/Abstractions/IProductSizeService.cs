using FinalApiTask.BL.DTOs.ProductColorDtos;
using FinalApiTask.BL.DTOs.ProductSizeDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Services.Abstractions
{
    public interface IProductSizeService
    {
        Task<ICollection<ProductSize>> GetAllAsync();
        Task<ProductSize> CreateAsync(ProductSizeCreateDto entityDto);
        Task<ProductSize> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
