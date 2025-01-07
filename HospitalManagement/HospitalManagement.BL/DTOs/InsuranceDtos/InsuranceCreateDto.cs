using FluentValidation;
using HospitalManagement.BL.DTOs.PatientDtos;
using HospitalManagement.Core.Entities;
using System.Text.RegularExpressions;

namespace HospitalManagement.BL.DTOs.InsuranceDtos
{
    public class InsuranceCreateDto
    {
        public string? PersonInsurance { get; set; }
        public float Discount { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }

    public class InsuranceCreateDtoValidation : AbstractValidator<InsuranceCreateDto>
    {
        public InsuranceCreateDtoValidation()
        {
            RuleFor(c => c.PersonInsurance).NotEmpty()
                .NotNull()
                .WithMessage("PersonInsurance cannot be empty")
                .MaximumLength(50).WithMessage("Maximum length is 50");
        }

       

    }
}
