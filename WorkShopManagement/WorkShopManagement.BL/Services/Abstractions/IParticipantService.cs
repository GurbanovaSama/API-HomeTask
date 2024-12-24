using WorkShopManagement.BL.DTOs.ParticipantDtos;
using WorkShopManagement.Core.Entities;

namespace WorkShopManagement.BL.Services.Abstractions
{
    public interface IParticipantService
    {
        Task<ICollection<Participant>> GetALLAsync();
        Task<Participant> CreateAsync(ParticipantCreateDto entityDto);
        Task<Participant> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ParticipantCreateDto entityDto);
    }
}

