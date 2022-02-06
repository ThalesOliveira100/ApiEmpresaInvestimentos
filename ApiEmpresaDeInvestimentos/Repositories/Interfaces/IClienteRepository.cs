using ApiEmpresaDeInvestimentos.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Repositories.Interfaces
{
    interface IClienteRepository
    {
        public void SalvarAlteracoes();
        public void AdicionarCliente(Cliente cliente);
        public List<Cliente> RecuperarTodosOsClientes();
        public Cliente RecuperarClientePorId(Guid id);
        public Result DeletarClientePorId(Guid id);

    }
}
