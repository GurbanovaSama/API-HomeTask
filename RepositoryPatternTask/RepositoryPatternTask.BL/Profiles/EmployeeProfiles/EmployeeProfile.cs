using AutoMapper;
using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.Profiles.EmployeeProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeCreateDto, Employee>().ReverseMap();
            //CreateMap<EmployeeUpdateDto, Employee>();
            //CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
        }
    }
}
