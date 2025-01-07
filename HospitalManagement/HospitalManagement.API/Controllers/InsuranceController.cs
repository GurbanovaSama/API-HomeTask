using HospitalManagement.BL.DTOs.InsuranceDtos;
using HospitalManagement.BL.DTOs.PatientDtos;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        public async Task<ICollection<Insurance>> GetAllAsync()
        {
            return await _insuranceService.GetALLAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Create(InsuranceCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status200OK, await _insuranceService.CreateAsync(createDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _insuranceService.GetByIdAsync(id));
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
                return StatusCode(StatusCodes.Status200OK, await _insuranceService.SoftDeleteAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }


        [HttpPut("updateinsurance/{id}")]
        public async Task<IActionResult> Update(int id, InsuranceCreateDto insuranceUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _insuranceService.UpdateAsync(id, insuranceUpdateDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
