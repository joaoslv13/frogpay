namespace FrogPay.Domain.Entities
{
    public sealed class DadosBancarios
    {
        public Guid PessoaId { get; set; }
        public string? CodigoBanco {  get; set; }
        public string? Agencia { get; set; }
        public string? Conta { get; set; }
        public string? DigitoConta { get; set; }
    }
}
