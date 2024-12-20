using WorkShopManagement.BL.DTOs.ParticipantDtos;
using WorkShopManagement.BL.Services.Abstractions;
using WorkShopManagement.Core.Entities;
using WorkShopManagement.DAL.Repositories.Abstractions;

namespace WorkShopManagement.BL.Services.Implementations
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepo;

        public ParticipantService(IParticipantRepository participantRepo)
        {
            _participantRepo = participantRepo;
        }

        public async Task<ICollection<Participant>> GetALLAsync()
        {
            return await _participantRepo.GetAllAsync();    
        }

        public async Task<Participant> CreateAsync(ParticipantCreateDto participantCreateDto)
        {
            Participant participant = new Participant();
            participant.Name = participantCreateDto.Name;
            participant.Email = participantCreateDto.Email; 
            participant.Phone = participantCreateDto.Phone;     
            participant.WorkShopId = participantCreateDto.WorkShopId;   
            participant.CreatedAt = DateTime.UtcNow.AddHours(4);
            participant.DeletedAt = DateTime.UtcNow.AddHours(4);    
            participant.UpdatedAt = DateTime.UtcNow.AddHours(4);
            participant.CreatedBy = "Sema";
            participant.DeletedBy = "Sema";

            var createdEntity = await _participantRepo.CreateAsync(participant);
            await _participantRepo.SaveChangeAsync();
            return createdEntity;   

        }

    }
}
