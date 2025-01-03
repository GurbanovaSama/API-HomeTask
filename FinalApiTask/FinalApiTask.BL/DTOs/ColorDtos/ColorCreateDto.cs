using FinalApiTask.Core.Entities;
using FluentValidation;

namespace FinalApiTask.BL.DTOs.ColorDtos
{
    public record ColorCreateDto
    {
        public string Name { get; set; }
    }

    public class ColorCreateDtoValidation : AbstractValidator<ColorCreateDto>
    {
        public ColorCreateDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty()
              .NotNull()
              .WithMessage("Name cannot be empty")
              .MaximumLength(25).WithMessage("Maximum length is 25");
        }
    }
}
