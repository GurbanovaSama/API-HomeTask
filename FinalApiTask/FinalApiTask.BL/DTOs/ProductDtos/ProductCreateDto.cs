using FluentValidation;

namespace FinalApiTask.BL.DTOs.ProductDtos
{
    public record ProductCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductCreateDtoValidation : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be empty")
                .MaximumLength(100).WithMessage("Maximum length is 100");
            RuleFor(b => b.Price).NotEmpty().NotNull()
                .WithMessage("Price cannot be null or empty")
                .GreaterThan(0).WithMessage(" Price can not be below 0");
        }
    }

}
