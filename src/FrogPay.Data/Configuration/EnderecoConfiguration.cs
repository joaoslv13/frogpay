using FrogPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FrogPay.Data.Configuration
{
    public static class EnderecoConfiguration
    {
        public static void EnderecoConfigure(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityConfigure<Endereco>();

            modelBuilder.Entity<Endereco>()
               .Property(x => x.UfEstado)
               .HasMaxLength(2)
               .IsRequired();

            modelBuilder.Entity<Endereco>()
              .Property(x => x.Cidade)
              .HasMaxLength(500)
              .IsRequired();

            modelBuilder.Entity<Endereco>()
              .Property(x => x.Bairro)
              .HasMaxLength(500)
              .IsRequired();

            modelBuilder.Entity<Endereco>()
             .Property(x => x.Logradouro)
             .HasMaxLength(500)
             .IsRequired();

            modelBuilder.Entity<Endereco>()
             .Property(x => x.Complemento)
             .HasMaxLength(500);

            modelBuilder.Entity<Endereco>()
             .HasOne(x => x.Pessoa)
             .WithMany(x => x.Enderecos)
             .HasForeignKey(x => x.PessoaId)
             .IsRequired();
        }
    }
}
