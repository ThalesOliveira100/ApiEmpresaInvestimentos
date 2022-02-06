using ApiEmpresaDeInvestimentos.Data.Dtos.Cliente;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Services.Interfaces
{
    interface IClienteService
    {
        public ReadClienteDto AdicionarCliente(CreateClienteDto clienteDto);
        public List<ReadClienteDto> RecuperarTodosOsClientes();
        public ReadClienteDto RecuperarClientePorId(Guid id);
        public Result AtualizarClientePorId(Guid id, UpdateClienteDto clienteDto);
        public Result DeletarClientePorId(Guid id);
    }
}
