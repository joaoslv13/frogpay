namespace FrogPay.Domain.Entities
{
    public sealed class DadosBancarios : BaseEntity
    {
        public Guid PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public string? CodigoBanco { get; set; }
        public string? Agencia { get; set; }
        public string? Conta { get; set; }
        public string? DigitoConta { get; set; }
    }
}
