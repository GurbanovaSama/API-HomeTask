using FinalApiTask.BL.DTOs.ColorDtos;
using FinalApiTask.BL.DTOs.ProductDtos;
using FinalApiTask.Core.Entities;
using Microsoft.AspNetCore.Http;

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
        Task<(bool Success, string Path, string Message)> UploadImageAsync(int id, IFormFile file);
    }
}
