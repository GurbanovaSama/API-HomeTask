using FluentValidation;
using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.Core.Entities;

namespace RepositoryPatternTask.BL.DTOs.DepartmentDtos
{
    public class DepartmentCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }


        public class DepartmentCreateDtoValidation : AbstractValidator<DepartmentCreateDto>
        {
            public DepartmentCreateDtoValidation()
            {
                RuleFor(e => e.Name).NotEmpty()
                    .WithMessage("FirstName cannot be empty")
                    .NotNull().WithMessage("FirstName cannot be null")
                    .MaximumLength(50).WithMessage("Maximum length is 50");

                RuleFor(e => e.Description).NotEmpty().NotNull()
                   .WithMessage("Description cannot be empty or null")
                   .MaximumLength(75).WithMessage("Maximum length is 75");

                RuleFor(e => e.Location).NotEmpty().NotNull()
                  .WithMessage("Location cannot be empty or null");

            }
        }
    }
}
