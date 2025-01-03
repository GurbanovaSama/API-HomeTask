using FinalApiTask.BL.DTOs.CategoryDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllAsync();  
        Task<Category> CreateAsync(CategoryCreateDto entityDto);    
        Task<Category> GetByIdAsync(int id);        
        Task<bool> SoftDeleteAsync(int id); 
        Task<bool> UpdateAsync(int id, CategoryCreateDto categoryUpdateDto);
        Task<bool> EditAsync(int id, CategoryEditDto categoryEditDto);  
    }
}
