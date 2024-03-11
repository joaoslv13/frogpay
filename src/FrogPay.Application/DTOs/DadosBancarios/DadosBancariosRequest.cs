namespace FrogPay.Application.DTOs.DadosBancarios
{
    public record DadosBancariosRequest(
        Guid PessoaId,
        string? CodigoBanco,
        string? Agencia,
        string? Conta,
        string? DigitoConta);
}