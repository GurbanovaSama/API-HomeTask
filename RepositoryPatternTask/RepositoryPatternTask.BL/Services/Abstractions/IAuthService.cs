using RepositoryPatternTask.BL.DTOs.AppUserDtos;

namespace RepositoryPatternTask.BL.Services.Abstractions
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(AppUserCreateDto entityCreateDto);
        Task<bool> ConfirmEmailAsync(string userId, string token);
        Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto);    
    }
}
