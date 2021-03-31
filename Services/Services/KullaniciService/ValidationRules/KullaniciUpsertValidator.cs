using Data.Extends;
using FluentValidation;

namespace Business.Services.KullaniciService.ValidationRules
{
    public class KullaniciUpsertValidator : AbstractValidator<KullaniciUpsertDto>
    {
        //todo: multiple dil eklenecek
        public KullaniciUpsertValidator()
        {
            RuleFor(x => x.AdiSoyadi).NotEmpty().OverridePropertyName("Adı Soyadı");
            RuleFor(x => x.KullaniciAdi).NotEmpty();
            RuleFor(x => x.KullaniciAdi).Length(3, 50).WithMessage("Ozel Mesaj ver");
        }
    }
}