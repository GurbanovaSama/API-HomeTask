using AutoMapper;
using HospitalManagement.BL.DTOs.PatientDtos;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Profiles.PatientProfiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<PatientCreateDto, Patient>().ReverseMap();
        }
    }
}

