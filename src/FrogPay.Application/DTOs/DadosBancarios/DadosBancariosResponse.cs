namespace FrogPay.Application.DTOs.DadosBancarios
{
    public record DadosBancariosResponse(
        Guid Id,
        Guid PessoaId,
        string? CodigoBanco,
        string? Agencia,
        string? Conta,
        string? DigitoConta);
}