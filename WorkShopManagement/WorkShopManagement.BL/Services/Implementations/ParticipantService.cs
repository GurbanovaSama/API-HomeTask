using AutoMapper;
using WorkShopManagement.BL.DTOs.ParticipantDtos;
using WorkShopManagement.BL.Exceptions.CommonExceptions;
using WorkShopManagement.BL.Services.Abstractions;
using WorkShopManagement.Core.Entities;
using WorkShopManagement.DAL.Repositories.Abstractions;

namespace WorkShopManagement.BL.Services.Implementations
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepo;
        private readonly IMapper _mapper;


        public ParticipantService(IParticipantRepository participantRepo, IMapper mapper)
        {
            _participantRepo = participantRepo;
            _mapper = mapper;
        }





        public async Task<Participant> CreateAsync(ParticipantCreateDto entityDto)
        {
            Participant createdParticipant = _mapper.Map<Participant>(entityDto);
            createdParticipant.CreatedAt = DateTime.UtcNow.AddHours(4);
            Participant participantEntity = await _participantRepo.CreateAsync(createdParticipant);
            await _participantRepo.SaveChangeAsync();
            return participantEntity;
        }


        public async Task<ICollection<Participant>> GetALLAsync()
        {
            return await _participantRepo.GetAllAsync();    
        }


        public async Task<Participant> GetByIdAsync(int id)
        {
            if (!await _participantRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _participantRepo.GetByIdAsync(id);
        }


        public async Task<bool> SoftDeleteAsync(int id)
        {
            var participantEntity = await GetByIdAsync(id);
            _participantRepo.SoftDelete(participantEntity);
            await _participantRepo.SaveChangeAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(int id, ParticipantCreateDto participantUpdateDto)
        {
            var participantEntity = await GetByIdAsync(id);
            Participant updatedParticipant = _mapper.Map<Participant>(participantUpdateDto);
            updatedParticipant.CreatedAt = DateTime.UtcNow.AddHours(4);
            updatedParticipant.Id = id;
            _participantRepo.Update(updatedParticipant);
            await _participantRepo.SaveChangeAsync();
            return true;
        }
    }
}
