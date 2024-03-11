using FluentValidation;
using FrogPay.Application.DTOs.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Validators.Endereco
{
    public class EnderecoRequestValidator : AbstractValidator<EnderecoRequest>
    {
        public EnderecoRequestValidator()
        {

        }
    }
}
