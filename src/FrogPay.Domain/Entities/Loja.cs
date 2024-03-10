namespace FrogPay.Domain.Entities
{
    public sealed class Loja : BaseEntity
    {
        public Guid PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public string? NomeFantasia { get; set; }

        public string? RazaoSocial { get; set; }

        public string? Cnpj { get; set; }

        public DateTime DataAbertura { get; set; }


    }
}
