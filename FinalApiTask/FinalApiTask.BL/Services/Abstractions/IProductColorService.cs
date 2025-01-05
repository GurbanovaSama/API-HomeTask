using FinalApiTask.BL.DTOs.ProductColorDtos;
using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.Repositories.Abstractions;

namespace FinalApiTask.BL.Services.Abstractions;

public interface IProductColorService 
{
    Task<ICollection<ProductColor>> GetAllAsync();
    Task<ProductColor> CreateAsync(ProductColorCreateDto entityDto);
    Task<ProductColor> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}
