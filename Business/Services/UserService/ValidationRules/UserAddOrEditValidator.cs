using DTOs.User;
using FluentValidation;

namespace Business.Services.UserService.ValidationRules
{
    public class UserAddOrEditValidator : AbstractValidator<UserExtendDto>
    {
        //todo: multiple dil eklenecek
        public UserAddOrEditValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().OverridePropertyName("Adı");
            RuleFor(x => x.Firstname).NotEmpty().OverridePropertyName("Soyadı");
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).Length(3, 50).WithMessage("Ozel Mesaj ver");
        }
    }
}