using ApiEmpresaDeInvestimentos.Data.Dtos.Cliente;
using ApiEmpresaDeInvestimentos.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Clientes>();
            CreateMap<Clientes, ReadClienteDto>();
            CreateMap<UpdateClienteDto, Clientes>();
        }
    }
}
