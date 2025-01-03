using FinalApiTask.BL.DTOs.AppUserDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Services.Abstractions
{
    public interface IAppUserService
    {
        Task<ICollection<AppUser>> GetAllAsync();
        Task<AppUser> CreateAsync(AppUserCreateDto entityDto);
        Task<AppUser> GetByIdAsync(int  id);       
        Task<bool> SoftDeleteAsync(int id); 
        Task<bool> UpdateAsync(int id, AppUserCreateDto appUserUpdateDto); 
        Task<bool> EditAsync(int id, AppUserEditDto appUserEditDto);   
    }
}
