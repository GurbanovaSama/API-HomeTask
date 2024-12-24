using FluentValidation;
using WorkShopManagement.BL.DTOs.WorkShopDtos;

namespace WorkShopManagement.BL.DTOs.ParticipantDtos
{
    public class ParticipantCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int WorkShopId { get; set; }
    }

    public class ParticipantCreateDtoValidation : AbstractValidator<ParticipantCreateDto>
    {
        public ParticipantCreateDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(50).WithMessage("Maximum length is 50");

            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email cannot be empty")
                .NotNull().WithMessage("Email cannot be null")
                .MaximumLength(50).WithMessage("Maximum length is 100");


            RuleFor(e => e.Phone).NotEmpty().NotNull()
                 .WithMessage("Phone cannot be empty or null");

            RuleFor(e => e.WorkShopId).NotEmpty().NotNull()
             .WithMessage("WorkShopId cannot be empty or null");
        }
    }
}
