using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using RepositoryPatternTask.BL.DTOs.AppUserDtos;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration; 
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(changePasswordDto.Email);
            if (user == null)
            {
                return false;
            }
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, changePasswordDto.NewPassword);

            return result.Succeeded;
        }



        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);    
            if (user == null)
            {
                return false;
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded;
        }



        public async Task<bool> RegisterAsync(AppUserCreateDto entityCreateDto)
        {
            AppUser user = _mapper.Map<AppUser>(entityCreateDto);
            var result = await _userManager.CreateAsync(user, entityCreateDto.Password);    
            if(!result.Succeeded)
            {
                throw new Exception("Could not create user");
            }
            return true;
        }




    }
}
