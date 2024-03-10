using FrogPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Configuration
{
    public static class PessoaConfiguration
    {
        public static void PessoaConfigure(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityConfigure<Pessoa>();

            modelBuilder.Entity<Pessoa>()
                .Property(x => x.Nome)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(x => x.Cpf)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Pessoa>()
                .Property(x => x.DataNascimento)                
                .IsRequired();
        }
    }
}
