using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.BL.Exceptions.CommonExceptions;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.DAL;

namespace RepositoryPatternTask.API.Controllers;

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
    public async Task<IActionResult> Create(EmployeeCreateDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        return StatusCode(StatusCodes.Status201Created, await _employeeService.CreateAsync(createDto));
    }


    [HttpGet]
    [Route("id")]
    public async Task<Employee> GetById(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _employeeService.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
    }
}
