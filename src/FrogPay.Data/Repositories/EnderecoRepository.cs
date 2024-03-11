using FrogPay.Data.Context;
using FrogPay.Data.Repositories;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
{
    public EnderecoRepository(AppDbContext context) : base(context)
    { }

    public async Task<List<Endereco>> GetByIdPessoa(Guid IdPessoa, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var skip = (pageNumber - 1) * pageSize;

        return await Context.Enderecos
            .Where(w => w.PessoaId == IdPessoa)
            .OrderBy(o => o.CreatedDate)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
    public async Task<List<Endereco>> GetByNomePessoa(string nomePessoa, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var skip = (pageNumber - 1) * pageSize;

        return await Context.Enderecos
            .Include(e => e.Pessoa)
            .Where(e => e.Pessoa != null && e.Pessoa.Nome!.ToLower().Contains(nomePessoa.ToLower()))
            .OrderBy(o => o.CreatedDate)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }


}
