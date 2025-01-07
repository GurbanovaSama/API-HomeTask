using HospitalManagement.BL.DTOs.PatientDtos;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ICollection<Patient>> GetAllAsync()
        {
            return await _patientService.GetALLAsync();
        }


        [HttpPost]
        public async Task<IActionResult> Create(PatientCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            return StatusCode(StatusCodes.Status200OK, await _patientService.CreateAsync(createDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _patientService.GetByIdAsync(id));
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
                return StatusCode(StatusCodes.Status200OK, await _patientService.SoftDeleteAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }


        [HttpPut("updatepatient/{id}")]
        public async Task<IActionResult> Update(int id, PatientCreateDto patientUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _patientService.UpdateAsync(id, patientUpdateDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
