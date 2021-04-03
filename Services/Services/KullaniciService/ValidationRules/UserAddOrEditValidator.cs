using Data.User;
using FluentValidation;

namespace Business.Services.KullaniciService.ValidationRules
{
    public class UserAddOrEditValidator : AbstractValidator<UserDetailDto>
    {
        //todo: multiple dil eklenecek
        public UserAddOrEditValidator()
        {
            RuleFor(x => x.AdiSoyadi).NotEmpty().OverridePropertyName("Adı Soyadı");
            RuleFor(x => x.KullaniciAdi).NotEmpty();
            RuleFor(x => x.KullaniciAdi).Length(3, 50).WithMessage("Ozel Mesaj ver");
        }
    }
}