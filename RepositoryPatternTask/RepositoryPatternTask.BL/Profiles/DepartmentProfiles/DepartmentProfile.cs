using AutoMapper;
using RepositoryPatternTask.BL.DTOs.DepartmentDtos;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.Profiles.DepartmentProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentCreateDto, Department>().ReverseMap();
        }
    }
}
