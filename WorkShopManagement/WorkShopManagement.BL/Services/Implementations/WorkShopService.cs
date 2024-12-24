using AutoMapper;
using WorkShopManagement.BL.DTOs.WorkShopDtos;
using WorkShopManagement.BL.Exceptions.CommonExceptions;
using WorkShopManagement.BL.Services.Abstractions;
using WorkShopManagement.Core.Entities;
using WorkShopManagement.DAL.Repositories.Abstractions;

namespace WorkShopManagement.BL.Services.Implementations
{
    public class WorkShopService : IWorkShopService
    {
        private readonly IWorkShopRepository _workShopRepo;
        private readonly IMapper _mapper;

        public WorkShopService(IWorkShopRepository workShopRepo, IMapper mapper)
        {
            _workShopRepo = workShopRepo;
            _mapper = mapper;
        }





        public async Task<WorkShop> CreateAsync(WorkShopCreateDto entityDto)
        {
            WorkShop createdWorkShop = _mapper.Map<WorkShop>(entityDto);
            createdWorkShop.CreatedAt = DateTime.UtcNow.AddHours(4);
            WorkShop workShopEntity = await _workShopRepo.CreateAsync(createdWorkShop);
            await _workShopRepo.SaveChangeAsync();
            return workShopEntity;
        }


        public async Task<ICollection<WorkShop>> GetALLAsync()
        {
            return await _workShopRepo.GetAllAsync();   
        }

        public async Task<WorkShop> GetByIdAsync(int id)
        {
            if (!await _workShopRepo.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _workShopRepo.GetByIdAsync(id);    
        }


        public async Task<bool> SoftDeleteAsync(int id)
        {
            var workShopEntity = await GetByIdAsync(id);
            _workShopRepo.SoftDelete(workShopEntity);
            await _workShopRepo.SaveChangeAsync();
            return true;
        }


        public async Task<bool> UpdateAsync(int id, WorkShopCreateDto workShopUpdateDto)
        {
            var workShopEntity = await GetByIdAsync(id);
            WorkShop updatedWorkShop = _mapper.Map<WorkShop>(workShopUpdateDto);
            updatedWorkShop.CreatedAt = DateTime.UtcNow.AddHours(4);
            updatedWorkShop.Id = id;
            _workShopRepo.Update(updatedWorkShop);
            await _workShopRepo.SaveChangeAsync();
            return true;
        }
    }
}
