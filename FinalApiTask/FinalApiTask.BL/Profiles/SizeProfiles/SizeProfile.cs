using AutoMapper;
using FinalApiTask.BL.DTOs.SizeDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Profiles.SizeProfiles
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<SizeCreateDto, Size>().ReverseMap();
            CreateMap<SizeEditDto, Size>().ReverseMap();    
        }
    }
}
