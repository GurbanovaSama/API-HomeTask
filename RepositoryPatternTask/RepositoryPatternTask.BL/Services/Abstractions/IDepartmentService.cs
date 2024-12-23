using RepositoryPatternTask.BL.DTOs.DepartmentDtos;
using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.Services.Abstractions
{
    public interface IDepartmentService 
    {
        Task<ICollection<Department>> GetALLAsync();
        Task<Department> CreateAsync(DepartmentCreateDto entityDto);
        Task<Department> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, DepartmentCreateDto entityDto);
    }
}
