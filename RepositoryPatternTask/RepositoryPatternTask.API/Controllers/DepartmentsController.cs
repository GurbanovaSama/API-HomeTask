using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternTask.BL.DTOs.DepartmentDtos;
using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.BL.Services.Implementations;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<ICollection<Department>> GetAllAsync()
    {
        return await _departmentService.GetALLAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentCreateDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        return StatusCode(StatusCodes.Status200OK, await _departmentService.CreateAsync(createDto));
    }




    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _departmentService.GetByIdAsync(id));
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
            return StatusCode(StatusCodes.Status200OK, await _departmentService.SoftDeleteAsync(id));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }


    [HttpPut("updateemployee/{id}")]
    public async Task<IActionResult> Update(int id, DepartmentCreateDto departmentUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _departmentService.UpdateAsync(id, departmentUpdateDto));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }



}
