using Microsoft.AspNetCore.Mvc;
using WorkShopManagement.BL.DTOs.ParticipantDtos;
using WorkShopManagement.BL.Services.Abstractions;
using WorkShopManagement.Core.Entities;

namespace WorkShopManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService _participantService;

        public ParticipantsController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet]
        public async Task<ICollection<Participant>> GetAll()
        {
            return await _participantService.GetALLAsync();
        }

        [HttpPost]
        public async Task<Participant> Create(ParticipantCreateDto createDto)
        {
            return await _participantService.CreateAsync(createDto);
        }
    }
}
