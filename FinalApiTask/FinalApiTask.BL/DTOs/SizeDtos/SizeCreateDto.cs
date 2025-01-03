using FluentValidation;

namespace FinalApiTask.BL.DTOs.SizeDtos
{
    public record SizeCreateDto
    {
        public string Name { get; set; }
    }

    public class SizeCreateDtoValidation : AbstractValidator<SizeCreateDto>
    {
        public SizeCreateDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be empty");
        }
    }
}
