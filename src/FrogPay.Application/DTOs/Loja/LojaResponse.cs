namespace FrogPay.Application.DTOs.Loja
{
    public record LojaResponse(
        Guid Id,
        Guid PessoaId,
        string? NomeFantasia,
        string? RazaoSocial,
        string? Cnpj,
        DateOnly DataAbertura,
        DateTime CreatedDate,
        DateTime UpdatedDate);
}