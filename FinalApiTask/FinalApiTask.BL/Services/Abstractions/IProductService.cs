using FinalApiTask.BL.DTOs.ColorDtos;
using FinalApiTask.BL.DTOs.ProductDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Services.Abstractions
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> CreateAsync(ProductCreateDto entityDto);
        Task<Product> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ProductCreateDto productUpdateDto);
        Task<bool> EditAsync(int id, ProductEditDto productEditDto);
    }
}
