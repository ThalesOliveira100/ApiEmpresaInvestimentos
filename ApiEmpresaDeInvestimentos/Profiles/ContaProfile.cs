using ApiEmpresaDeInvestimentos.Data.Dtos.Conta;
using ApiEmpresaDeInvestimentos.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Profiles
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<CreateContaDto, Conta>();
            CreateMap<Conta, ReadContaDto>();
            CreateMap<UpdateContaDto, Conta>();
        }
    }
}
