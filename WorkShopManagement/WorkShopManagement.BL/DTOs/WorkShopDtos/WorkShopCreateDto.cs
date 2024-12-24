using FluentValidation;

namespace WorkShopManagement.BL.DTOs.WorkShopDtos
{
    public class WorkShopCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }

    public class WorkShopCreateDtoValidation : AbstractValidator<WorkShopCreateDto>
    {
        public WorkShopCreateDtoValidation()
        {
            RuleFor(x =>  x.Title).NotEmpty()
                .WithMessage("Title cannot be empty")
                .NotNull().WithMessage("Title cannot be null")
                .MaximumLength(50).WithMessage("Maximum length is 50");

            RuleFor(x => x.Description).NotEmpty()
                .WithMessage("Description cannot be empty")
                .NotNull().WithMessage("Description cannot be null")
                .MaximumLength(50).WithMessage("Maximum length is 300");


            RuleFor(e => e.Location).NotEmpty().NotNull()
                 .WithMessage("Location cannot be empty or null");

            RuleFor(e => e.Date).NotEmpty().NotNull()
             .WithMessage("Date cannot be empty or null");
        }
    }


}
