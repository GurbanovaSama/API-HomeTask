using FluentValidation;
using System.Text.RegularExpressions;

namespace FinalApiTask.BL.DTOs.AppUserDtos
{
    public record AppUserCreateDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AppUserCreateDtoValidation : AbstractValidator<AppUserCreateDto> 
    {
        public AppUserCreateDtoValidation()
        {
            RuleFor(x => x.UserName).NotEmpty()
                 .NotNull()
                 .WithMessage("Name cannot be empty")
                 .MaximumLength(50).WithMessage("Maximum length is 50");
            RuleFor(x => x.Email).NotEmpty()
                .NotNull()
                .WithMessage("Email cannot be empty")
                 .MaximumLength(80).WithMessage("Maximum length is 80");
            RuleFor(x => x.Password).NotEmpty()
              .NotNull()
              .WithMessage("Password cannot be empty")
               .MaximumLength(12).WithMessage("Maximum length is 12");
        }


        public bool BeValidEmailAddress(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) { return true; }
            return false;
        }
    }
}
