using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternTask.BL.DTOs.DepartmentDtos;
using RepositoryPatternTask.BL.Services.Abstractions;
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
}
