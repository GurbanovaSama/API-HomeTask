using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryPatternTask.BL.DTOs.AppUserDtos;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
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
