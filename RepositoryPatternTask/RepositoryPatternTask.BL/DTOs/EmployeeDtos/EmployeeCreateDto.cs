using FluentValidation;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.DTOs.EmployeeDtos
{
    public record EmployeeCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
    }

    public class EmployeeCreateDtoValidation : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidation()
        {
            RuleFor(e => e.FirstName).NotEmpty()
                .WithMessage("FirstName cannot be empty")
                .NotNull().WithMessage("FirstName cannot be null")
                .MaximumLength(50).WithMessage("Maximum length is 50");

            RuleFor(e => e.LastName).NotEmpty().NotNull()
               .WithMessage("LastName cannot be empty or null")
               .MaximumLength(75).WithMessage("Maximum length is 75");

            RuleFor(e => e.Email).NotEmpty().NotNull()
              .WithMessage("Email cannot be empty or null");

            RuleFor(e => e.PhoneNumber).NotEmpty().NotNull()
            .WithMessage("PhoneNumber cannot be empty or null");

            RuleFor(e => e.Position).NotEmpty().NotNull()
           .WithMessage("Position cannot be empty or null");




        }
    }


}
