using FluentValidation;
using FrogPay.Application.DTOs.Pessoa;
using FrogPay.Application.Shared;

namespace FrogPay.Application.Validators
{
    public class PessoaRequestValidator : AbstractValidator<PessoaRequest>
    {
        public PessoaRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .NotNull().WithMessage("O Nome é obrigatório.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O Cpf é obrigatório.")
                .Must(CpfValidator.IsValid!).WithMessage("Cpf inválido");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .NotNull().WithMessage("A data de nascimento é obrigatória.");
        }
    }
}
