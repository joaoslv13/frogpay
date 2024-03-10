using FrogPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Configuration
{
    public static class LojaConfiguration
    {
        public static void LojaConfigure(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityConfigure<Loja>();

            modelBuilder.Entity<Loja>()
                .Property(x => x.NomeFantasia)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Loja>()
                .Property(x => x.RazaoSocial)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Loja>()
                .Property(x => x.Cnpj)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Loja>()
                .Property(x => x.DataAbertura)
                .IsRequired();

            modelBuilder.Entity<Loja>()
             .HasOne(x => x.Pessoa)
             .WithMany(x => x.Lojas)
             .HasForeignKey(x => x.PessoaId)
             .IsRequired();
        }
    }
}
