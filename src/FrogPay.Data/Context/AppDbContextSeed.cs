using FrogPay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Data.Context
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.Usuarios.Any())
            {
                context.Usuarios.AddRange(GetPreconfiguredUsuarios());
                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<Usuario> GetPreconfiguredUsuarios()
        {
            return new List<Usuario>
            {
                new Usuario() { Login = "Joao", Senha = "5F4DCC3B5AA765D61D8327DEB882CF99"}
            };
        }
    }
}
