using AutoMapper;
using RepositoryPatternTask.BL.DTOs.AppUserDtos;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.Profiles.AppUserProfiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserCreateDto, AppUser>();
        }
    }
}
