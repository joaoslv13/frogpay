using AutoMapper;
using FrogPay.Application.DTOs.Pessoa;
using FrogPay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Mappers
{
    public class PessoaMapper : Profile
    {
        public PessoaMapper()
        {
                CreateMap<Pessoa, PessoaResponse>().ReverseMap();
        }
    }
}
