namespace FrogPay.Domain.Entities
{
    public sealed class Pessoa : BaseEntity
    {
        public string? Nome { get; set; }

        public string? Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

    }
}
