using AutoMapper;
using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.BL.Exceptions.CommonExceptions;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.Repositories.Abstractions;

namespace RepositoryPatternTask.BL.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<ICollection<Employee>> GetALLAsync()
        {
            return await _employeeRepo.GetAllAsync();    
        }

        public async Task<Employee> CreateAsync(EmployeeCreateDto entityDto)
        {
            Employee createdEmployee = _mapper.Map<Employee>(entityDto);
            createdEmployee.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _employeeRepo.CreateAsync(createdEmployee);  
            await _employeeRepo.SaveChangesAsync(); 
            return createdEntity;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            if(!await _employeeRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _employeeRepo.GetByIdAsync(id);   
        }



        public async Task<bool> SoftDeleteAsync(int id)
        {
            var employeeEntity = await GetByIdAsync(id);
            _employeeRepo.SoftDelete(employeeEntity);
            await _employeeRepo.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> UpdateAsync(int id, EmployeeCreateDto employeeUpdateDto)
        {
            var employeeEntity = await GetByIdAsync(id);
            Employee updatedEmployee = _mapper.Map<Employee>(employeeUpdateDto);
            updatedEmployee.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedEmployee.Id = id;
            _employeeRepo.Update(updatedEmployee);  
            _employeeRepo.Update(updatedEmployee);
            await _employeeRepo.SaveChangesAsync();
            return true;
        }
    }
}
