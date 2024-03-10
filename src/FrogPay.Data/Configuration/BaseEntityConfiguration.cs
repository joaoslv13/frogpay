using FrogPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Configuration
{
    public static class BaseEntityConfiguration
    {
        public static void BaseEntityConfigure<T>(this ModelBuilder modelBuilder) where T : BaseEntity
        {
            modelBuilder.Entity<T>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<T>()
                .Property(x => x.CreatedDate)
                .IsRequired();
        }
    }
}
