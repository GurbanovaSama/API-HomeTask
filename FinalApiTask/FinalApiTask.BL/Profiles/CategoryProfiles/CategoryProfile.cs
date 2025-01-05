using AutoMapper;
using FinalApiTask.BL.DTOs.CategoryDtos;
using FinalApiTask.Core.Entities;

namespace FinalApiTask.BL.Profiles.CategoryProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryCreateDto, Category>().ReverseMap();  
            CreateMap<CategoryEditDto, Category>().ReverseMap();    
        }
    }
}
