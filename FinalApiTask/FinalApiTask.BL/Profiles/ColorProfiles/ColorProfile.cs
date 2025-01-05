using AutoMapper;
using FinalApiTask.BL.DTOs.ColorDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Profiles.ColorProfiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<ColorCreateDto, Color>().ReverseMap();   
            CreateMap<ColorEditDto, Color>().ReverseMap();  
        }
    }
}
