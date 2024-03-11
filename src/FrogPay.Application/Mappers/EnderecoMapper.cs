using AutoMapper;
using FrogPay.Application.DTOs.Endereco;
using FrogPay.Domain.Entities;

namespace FrogPay.Application.Mappers
{
    public class EnderecoMapper : Profile
    {
        public EnderecoMapper()
        {
            CreateMap<Endereco, EnderecoResponse>().ReverseMap();
            CreateMap<Endereco, EnderecoRequest>().ReverseMap();
        }
    }
}
