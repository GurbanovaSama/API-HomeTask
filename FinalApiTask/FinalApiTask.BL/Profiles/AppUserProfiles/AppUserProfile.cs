using AutoMapper;
using FinalApiTask.BL.DTOs.AppUserDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Profiles.AppUserProfiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserCreateDto, AppUser>();
        }
    }
}
