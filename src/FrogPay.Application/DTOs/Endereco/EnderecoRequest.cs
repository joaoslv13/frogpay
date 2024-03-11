using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.DTOs.Endereco
{
    public record EnderecoRequest(
        Guid PessoaId,
        string? UfEstado,
        string? Cidade,
        string? Bairro,
        string? Logradouro,
        string? Numero,
        string? Complemento);
}
