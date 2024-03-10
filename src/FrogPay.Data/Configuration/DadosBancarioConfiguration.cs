using FrogPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Configuration
{
    public static class DadosBancarioConfiguration
    {
        public static void DadosBancarioConfigure(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityConfigure<DadosBancario>();

            modelBuilder.Entity<DadosBancario>()
               .Property(x => x.CodigoBanco)
               .IsRequired();

            modelBuilder.Entity<DadosBancario>()
               .Property(x => x.Agencia)
               .IsRequired();

            modelBuilder.Entity<DadosBancario>()
               .Property(x => x.Conta)
               .IsRequired();

            modelBuilder.Entity<DadosBancario>()
               .Property(x => x.DigitoConta)
               .IsRequired();

            modelBuilder.Entity<DadosBancario>()
                .HasOne(x => x.Pessoa)
                .WithMany(x => x.DadosBancarios)
                .HasForeignKey(x => x.PessoaId)
                .IsRequired();
        }
    }
}
