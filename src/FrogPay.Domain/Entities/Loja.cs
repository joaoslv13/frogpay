namespace FrogPay.Domain.Entities
{
    public sealed class Loja
    {
        public Guid PessoaId { get; set; }
        public string? NomeFantasia { get; set; }

        public string? RazaoSocial { get; set; }

        public string? Cnpj {  get; set; }

        public DateTime DataAbertura { get; set; }

    }
}
