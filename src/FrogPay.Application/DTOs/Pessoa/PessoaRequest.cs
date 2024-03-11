namespace FrogPay.Application.DTOs.Pessoa
{
    public record PessoaRequest(string? Nome, string? Cpf, DateOnly DataNascimento);
}