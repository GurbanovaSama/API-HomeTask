using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService department)
    {
        _departmentService = department;
    }

    [HttpGet]
    public async Task<ICollection<Department>> GetAllAsync()
    {
        return await _departmentService.GetALLAsync();
    }
}
