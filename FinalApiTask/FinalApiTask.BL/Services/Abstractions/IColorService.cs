using FinalApiTask.BL.DTOs.CategoryDtos;
using FinalApiTask.BL.DTOs.ColorDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Services.Abstractions
{
    public interface IColorService
    {
        Task<ICollection<Color>> GetAllAsync();
        Task<Color> CreateAsync(ColorCreateDto entityDto);
        Task<Color> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ColorCreateDto colorUpdateDto);
        Task<bool> EditAsync(int id, ColorEditDto colorEditDto);
    }
}
