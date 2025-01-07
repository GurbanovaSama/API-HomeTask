using AutoMapper;
using HospitalManagement.BL.DTOs.InsuranceDtos;
using HospitalManagement.BL.DTOs.PatientDtos;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Profiles.InsuranceProfiles
{
    public class InsuranceProfile : Profile
    {
        public InsuranceProfile()
        {
            CreateMap<InsuranceCreateDto, Insurance>();
            CreateMap<InsuranceCreateDto, Insurance>().ReverseMap();
        }
    }
}
