using ApiProject.WepApi.Entities;
using FluentValidation;

namespace ApiProject.WepApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Ürün adını boş geçmeyiniz")
                .MinimumLength(2).WithMessage("En az 2 karekter veri girişi yazınız")
                .MaximumLength(50).WithMessage("En fazla 50 kareter veri girişi yazınız");

            RuleFor(x=>x.Price)
                .NotEmpty().WithMessage("Ürün fiyatı boş geçilemez")
                .GreaterThan(0).WithMessage("Ürün fiyatı 0 dan küçük olamaz")
                .LessThan(1000).WithMessage("Ürün fiyatı bu kadar yüksek olamaz");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Ürün açıklaması boş geçilemez");

        }
    }
}
