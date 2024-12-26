using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.BL.Exceptions.CommonExceptions;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.DAL;

namespace RepositoryPatternTask.API.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IEmployeeService _employeeService;



    public EmployeesController(IEmployeeService employee, AppDbContext context)
    {
        _employeeService = employee;
        _context = context;
    }



    [HttpGet]
    public async Task<ICollection<Employee>> GetAll()
    {
        return await _employeeService.GetALLAsync();   
    }


    //[HttpPost]
    //public async Task<IActionResult> Create(EmployeeCreateDto createDto)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return StatusCode(StatusCodes.Status400BadRequest, ModelState);
    //    }
    //    return StatusCode(StatusCodes.Status201Created, await _employeeService.CreateAsync(createDto));
    //}


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
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



    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _employeeService.SoftDeleteAsync(id));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }



    [HttpPut("updateemployee/{id}" )]
    public async Task<IActionResult> Update(int id, EmployeeCreateDto employeeUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _employeeService.UpdateAsync(id, employeeUpdateDto));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }


    public override bool Equals(object? obj)
    {
        return obj is EmployeesController controller &&
               EqualityComparer<AppDbContext>.Default.Equals(_context, controller._context);
    }


    [HttpPost("create")]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto dto)
    {
        var department = await _context.Departments.FindAsync(dto.DepartmentId);
        if (department == null)
        {
            return NotFound("Department tapılmadı.");
        }

        var employee = new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Position = dto.Position,
            DepartmentId = dto.DepartmentId,
            IsActive = true
        };

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
    }
}
