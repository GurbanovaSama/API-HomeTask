using RepositoryPatternTask.BL.DTOs.DepartmentDtos;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.Services.Abstractions
{
    public interface IDepartmentService 
    {
        Task<ICollection<Department>> GetALLAsync();
        Task<Department> CreateAsync(DepartmentCreateDto entityDto);
    }
}
