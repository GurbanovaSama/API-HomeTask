using AutoMapper;
using FinalApiTask.BL.DTOs.AppUserDtos;
using FinalApiTask.BL.Exceptions.CommonExceptions;
using FinalApiTask.BL.ExternalServices.Interfaces;
using FinalApiTask.BL.Services.Abstractions;
using FinalApiTask.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinalApiTask.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService; 
        private readonly IMapper _mapper;

        public AuthService(UserManager<AppUser> userManager, IMapper mapper, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> LoginAsync(AppUserLoginDto entityLoginDto)
        {
            AppUser? existingUser = await _userManager.FindByNameAsync(entityLoginDto.UserName);
            if (existingUser == null) { throw new EntityNotFoundException(); }
            bool result = await _userManager.CheckPasswordAsync(existingUser, entityLoginDto.Password);
            if (!result) { throw new Exception("Username or password is wrong"); }
            string token = _jwtTokenService.GenerateToken(existingUser);
            return token;
        }

        public async Task<bool> RegisterAsync(AppUserCreateDto entityCreateDto)
        {
            AppUser user = _mapper.Map<AppUser>(entityCreateDto);
            var result = await _userManager.CreateAsync(user, entityCreateDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Could not create user");
            }
            return true;
        }
    }
}
