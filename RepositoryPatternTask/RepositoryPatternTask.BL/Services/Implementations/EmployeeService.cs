using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.Repositories.Abstractions;
using RepositoryPatternTask.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTask.BL.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeService(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<ICollection<Employee>> GetALLAsync()
        {
            return await _employeeRepo.GetAllAsync();    
        }

        public async Task<Employee> CreateAsync(EmployeeCreateDto entityDto)
        {
            Employee employee = new Employee();  
            employee.FirstName = entityDto.FirstName;
            employee.LastName = entityDto.LastName;
            employee.Email = entityDto.Email;
            employee.PhoneNumber = entityDto.PhoneNumber;   
            employee.Position = entityDto.Position; 
            employee.DepartmentId = entityDto.DepartmentId;
            employee.CreatedAt = DateTime.UtcNow.AddHours(4);
            employee.UpdatedAt = DateTime.UtcNow.AddHours(4);
            employee.DeletedAt = DateTime.UtcNow.AddHours(4);
            employee.CreatedBy = "Sema";
            employee.DeletedBy = "Sema";

            var createdEntity = await _employeeRepo.CreateAsync(employee);  
            await _employeeRepo.SaveChangesAsync(); 
            return createdEntity;
        }
    }
}
