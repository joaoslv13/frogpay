namespace FrogPay.Application.DTOs.Loja
{
    public record LojaRequest(        
        Guid PessoaId,
        string? NomeFantasia,
        string? RazaoSocial,
        string? Cnpj,
        DateOnly DataAbertura);
}
