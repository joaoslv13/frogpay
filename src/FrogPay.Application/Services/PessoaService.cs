using AutoMapper;
using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.Pessoa;
using FrogPay.Application.Interfaces;
using FrogPay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Services
{
    internal class PessoaService : IPessoaService
    {
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<PaginationResponse<PessoaResponse>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var pessoas = await _pessoaRepository.GetAll(pageNumber, pageSize, cancellationToken);
            var pessoasDTO = _mapper.Map<List<PessoaResponse>>(pessoas);

            return new PaginationResponse<PessoaResponse>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Items = pessoasDTO
            };
        }
    }
}
