namespace FrogPay.Domain.Entities
{
    public sealed class Endereco : BaseEntity
    {
        public Guid PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public string? UfEstado { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
