namespace FrogPay.Application.DTOs.Pessoa
{
    public record PessoaResponse(
        Guid Id,
        string? Nome,
        string? Cpf,
        DateOnly DataNascimento,
        DateTime CreatedDate,
        DateTime UpdatedDate
    );


}
