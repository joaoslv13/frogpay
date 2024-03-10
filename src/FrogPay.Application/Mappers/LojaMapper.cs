using AutoMapper;
using FrogPay.Application.DTOs.Loja;
using FrogPay.Domain.Entities;

namespace FrogPay.Application.Mappers
{
    public class LojaMapper : Profile
    {
        public LojaMapper()
        {
            CreateMap<Loja, LojaResponse>().ReverseMap();
            CreateMap<Loja, LojaRequest>().ReverseMap();
        }
    }
}
