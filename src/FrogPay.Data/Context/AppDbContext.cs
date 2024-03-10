using FrogPay.Data.Configuration;
using FrogPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrogPay.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<DadosBancario> DadosBancarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.PessoaConfigure();
            modelBuilder.LojaConfigure();
            modelBuilder.EnderecoConfigure();
            modelBuilder.DadosBancarioConfigure();
            modelBuilder.UsuarioConfigure();
        }
    }
}
