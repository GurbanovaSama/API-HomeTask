using FluentValidation;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Entities.Enums;
using System.Text.RegularExpressions;

namespace HospitalManagement.BL.DTOs.PatientDtos
{
    public class PatientCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SeriaNumber { get; set; }
        public string? RegistrationAddress { get; set; }
        public string? CurrentAddress { get; set; }
        public string? Email { get; set; }
        public int InsuranceId { get; set; }
        public Gender Gender { get; set; }
        public BloodGroup BloodGroup { get; set; }
    }

    public class PatientCreateDtoValidation : AbstractValidator<PatientCreateDto>
    {
        public PatientCreateDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be empty")
                .MaximumLength(50).WithMessage("Maximum length is 50");
            RuleFor(c => c.Surname).NotEmpty()
                .NotNull()
                .WithMessage("Surname cannot be empty")
                .MaximumLength(100).WithMessage("Maximum length is 100");
        }

        public bool BeValidEmailAddress(string email)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            Match match = regex.Match(email);
            return match.Success;
        }

    }
}
