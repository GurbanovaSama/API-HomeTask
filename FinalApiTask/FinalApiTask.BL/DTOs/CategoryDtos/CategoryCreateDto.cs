using FluentValidation;

namespace FinalApiTask.BL.DTOs.CategoryDtos
{
    public record CategoryCreateDto
    {
        public string Name { get; set; }
    }

    public class CategoryCreateDtoVaidation : AbstractValidator<CategoryCreateDto> 
    {
        public CategoryCreateDtoVaidation()
        {
            RuleFor(c => c.Name).NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be empty")
                .MaximumLength(100).WithMessage("Maximum length is 100");
           
        }
    }

}
