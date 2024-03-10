using FluentValidation;
using FrogPay.Application.DTOs.Loja;
using FrogPay.Application.Shared;

namespace FrogPay.Application.Validators.Loja
{
    public class LojaRequestValidator : AbstractValidator<LojaRequest>
    {
        public LojaRequestValidator()
        {
            RuleFor(x => x.NomeFantasia)
                .NotEmpty().WithMessage("O nome fantasia é obrigatório.")
                .NotNull().WithMessage("O nome fantasia é obrigatório.");

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("O Cnpj é obrigatório.")
                .NotNull().WithMessage("O Cnpj é obrigatório.")
                .Must(CnpjValidator.IsValid!).WithMessage("Cnpj inválido");

            RuleFor(x => x.RazaoSocial)
                .NotEmpty().WithMessage("A razao social é obrigatória.")
                .NotNull().WithMessage("A razao social é obrigatória.");

            RuleFor(x => x.DataAbertura)
                .NotEmpty().WithMessage("A data abertura é obrigatoria.")
                .NotNull().WithMessage("A data Social é obrigatória.");
        }
    }
}
