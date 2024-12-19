using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternTask.BL.Services.Abstractions
{
    public interface IEmployeeService 
    {
        Task<ICollection<Employee>> GetALLAsync();
        Task<Employee> CreateAsync(EmployeeCreateDto entityDto);      


    }
}
