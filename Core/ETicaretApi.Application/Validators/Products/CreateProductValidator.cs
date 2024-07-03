using ETicaretApi.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
                .WithMessage("Lütfen ürün adını giriniz!")
            .MinimumLength(2)
            .MaximumLength(50)
                .WithMessage("Ürün adı minimum 5, maksimum 50 karakterden oluşabilir.");
            RuleFor(s => s.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Stok bilgisini giriniz!")
                .Must(s => s > 0)
                    .WithMessage("Stok adeti 0 veya negatif değerler alamaz");
            RuleFor(s => s.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen fiyat bilgisini giriniz!")
                .Must(s => s > 0)
                    .WithMessage("Fiyat 0 veya negatif değerler alamaz");


        }
    }
}
