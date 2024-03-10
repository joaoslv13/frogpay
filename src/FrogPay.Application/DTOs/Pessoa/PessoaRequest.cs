using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.DTOs.Pessoa
{
    public class PessoaRequest
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
