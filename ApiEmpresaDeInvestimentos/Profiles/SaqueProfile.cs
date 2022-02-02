using ApiEmpresaDeInvestimentos.Data.Dtos.Saque;
using ApiEmpresaDeInvestimentos.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Profiles
{
    public class SaqueProfile : Profile
    {
        public SaqueProfile()
        {
            CreateMap<CreateSaqueDto, Saques>();
            CreateMap<Saques, ReadSaqueDto>();
            CreateMap<UpdateSaqueDto, Saques>();
        }
    }
}
