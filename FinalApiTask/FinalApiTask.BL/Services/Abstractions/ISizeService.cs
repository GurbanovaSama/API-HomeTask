using FinalApiTask.BL.DTOs.ProductDtos;
using FinalApiTask.BL.DTOs.SizeDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Services.Abstractions
{
    public interface ISizeService
    {
        Task<ICollection<Size>> GetAllAsync();
        Task<Size> CreateAsync(SizeCreateDto entityDto);
        Task<Size> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, SizeCreateDto sizeUpdateDto);
        Task<bool> EditAsync(int id, SizeEditDto sizeEditDto);
    }
}
