using FrogPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Configuration
{
    public static class DadosBancarioConfiguration
    {
        public static void DadosBancarioConfigure(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityConfigure<DadosBancarios>();

            modelBuilder.Entity<DadosBancarios>()
               .Property(x => x.CodigoBanco)
               .IsRequired();

            modelBuilder.Entity<DadosBancarios>()
               .Property(x => x.Agencia)
               .IsRequired();

            modelBuilder.Entity<DadosBancarios>()
               .Property(x => x.Conta)
               .IsRequired();

            modelBuilder.Entity<DadosBancarios>()
               .Property(x => x.DigitoConta)
               .IsRequired();

            modelBuilder.Entity<DadosBancarios>()
                .HasOne(x => x.Pessoa)
                .WithMany(x => x.DadosBancarios)
                .HasForeignKey(x => x.PessoaId)
                .IsRequired();
        }
    }
}
