using FinalApiTask.BL.DTOs.AppUserDtos;

namespace FinalApiTask.BL.Services.Abstractions
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(AppUserCreateDto entityCreateDto);
        Task<string> LoginAsync(AppUserLoginDto entityLoginDto);
    }
}
