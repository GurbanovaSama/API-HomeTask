using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkShopManagement.BL.DTOs.WorkShopDtos;
using WorkShopManagement.BL.Services.Abstractions;
using WorkShopManagement.Core.Entities;

namespace WorkShopManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShopsController : ControllerBase
    {
        private readonly IWorkShopService _workShopService;

        public WorkShopsController(IWorkShopService workShopService)
        {
            _workShopService = workShopService;
        }

        [HttpGet]
        public async Task<ICollection<WorkShop>> GetAllAsync()
        {
            return await _workShopService.GetALLAsync();
        }



        [HttpPost]
        public async Task<IActionResult> Create(WorkShopCreateDto  createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status200OK, await _departmentService.CreateAsync(createDto));
        }
    }
}
