using ApiEmpresaDeInvestimentos.Data.Dtos.Deposito;
using ApiEmpresaDeInvestimentos.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Profiles
{
    public class DepositoProfile : Profile
    {
        public DepositoProfile()
        {
            CreateMap<CreateDepositoDto, Depositos>();
            CreateMap<Depositos, ReadDepositoDto>();
            CreateMap<UpdateDepositoDto, Depositos>();
        }
    }
}
