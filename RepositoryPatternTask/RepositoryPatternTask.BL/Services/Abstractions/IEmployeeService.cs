using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.Services.Abstractions
{
    public interface IEmployeeService 
    {
        Task<ICollection<Employee>> GetALLAsync();
        Task<Employee> CreateAsync(EmployeeCreateDto entityDto);
        Task<Employee> GetByIdAsync(int id);


    }
}
