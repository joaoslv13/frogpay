using AutoMapper;
using FrogPay.Application.DTOs.DadosBancarios;
using FrogPay.Application.DTOs.Loja;
using FrogPay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Mappers
{
    public class DadosBancariosMapper : Profile
    {
        public DadosBancariosMapper()
        {
            CreateMap<DadosBancarios, DadosBancariosRequest>().ReverseMap();
            CreateMap<DadosBancarios, DadosBancariosResponse>().ReverseMap();
        }

    }
}
