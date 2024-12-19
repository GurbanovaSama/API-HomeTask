using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.DAL;

namespace RepositoryPatternTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employee)
        {
            _employeeService = employee;
        }

        [HttpGet]
        public async Task<ICollection<Employee>> GetAll()
        {
            return await _employeeService.GetALLAsync();   
        }

        [HttpPost]
        public async Task<Employee> Create(EmployeeCreateDto createDto)
        {
            return await _employeeService.CreateAsync(createDto);
        }

    }
}
