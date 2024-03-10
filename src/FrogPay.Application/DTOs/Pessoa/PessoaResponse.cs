using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.DTOs.Pessoa
{
    public class PessoaResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
