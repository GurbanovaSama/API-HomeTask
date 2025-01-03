using AutoMapper;
using FinalApiTask.BL.DTOs.AppUserDtos;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.Core.Entities;
using FinalApiTask.DAL.Repositories.Abstractions;

namespace FinalApiTask.BL.Services.Implementations
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepo _appUserRepo;
        private readonly IMapper _mapper;

        public AppUserService(IAppUserRepo appUserRepo, IMapper mapper)
        {
            _appUserRepo = appUserRepo;
            _mapper = mapper;
        }



        public async Task<AppUser> CreateAsync(AppUserCreateDto entityDto)
        {
            AppUser createdAppUser = _mapper.Map<AppUser>(entityDto);
            createdAppUser.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _appUserRepo.CreateAsync(createdAppUser);
            await _appUserRepo.SaveChangesAsync();
            return createdEntity;   
        }


        public async Task<ICollection<AppUser>> GetAllAsync()
        {
            return await _appUserRepo.GetAllAsync();    
        }


        public async Task<AppUser> GetByIdAsync(int id)
        {
            if(!await _appUserRepo.IsExistsAsync(id))
            {
                throw new EntryPointNotFoundException();
            }
            return await _appUserRepo.GetByIdAsync(id); 
        }


        public async Task<bool> SoftDeleteAsync(int id)
        {
            var appUserEntity = await GetByIdAsync(id);
            _appUserRepo.SoftDelete(appUserEntity); 
            await _appUserRepo.SaveChangesAsync();  
            return true;    
        }


        public async Task<bool> UpdateAsync(int id, AppUserCreateDto appUserUpdateDto)
        {
            var appUserEntity = await GetByIdAsync(id);
            AppUser updatedAppUser = _mapper.Map<AppUser>(appUserUpdateDto);
            updatedAppUser.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedAppUser.Id = id; 
            _appUserRepo.Update(updatedAppUser);
            await _appUserRepo.SaveChangesAsync();
            return true;
        }


        public async Task<bool> EditAsync(int id, AppUserEditDto appUserEditDto)
        {
            var appUserEntity = await GetByIdAsync(id);
            _mapper.Map(appUserEditDto, appUserEntity);
            appUserEntity.UpdatedAt = DateTime.UtcNow.AddHours(4);
            _appUserRepo.Update(appUserEntity);
            await _appUserRepo.SaveChangesAsync();
            return true;
        }

        
    }
}
