using WorkShopManagement.BL.DTOs.ParticipantDtos;
using WorkShopManagement.Core.Entities;

namespace WorkShopManagement.BL.Services.Abstractions
{
    public interface IParticipantService
    {
        Task<ICollection<Participant>> GetALLAsync();
        Task<Participant> CreateAsync(ParticipantCreateDto entityDto);
    }
}
