using FrogPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Configuration
{
    public static class UsuarioConfiguration
    {
        public static void UsuarioConfigure(this ModelBuilder modelBuilder)
        {
            modelBuilder.BaseEntityConfigure<Usuario>();

            modelBuilder.Entity<Usuario>()
               .Property(x => x.Login)
               .HasMaxLength(500)
               .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(x => x.Senha)
                .HasMaxLength(500)
                .IsRequired();

        }
    }
}
