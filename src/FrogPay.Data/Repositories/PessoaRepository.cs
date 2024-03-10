using FrogPay.Data.Context;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(AppDbContext context) : base(context)
        { }
    }
}
