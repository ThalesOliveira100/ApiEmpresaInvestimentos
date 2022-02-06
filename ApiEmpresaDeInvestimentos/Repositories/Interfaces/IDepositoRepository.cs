using ApiEmpresaDeInvestimentos.Data.Dtos.Deposito;
using ApiEmpresaDeInvestimentos.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Repositories.Interfaces
{
    interface IDepositoRepository
    {
        public void SalvarAlteracoes();
        public Result AdicionarDeposito(Deposito deposito);
        public Deposito RecuperarDepositoPorId(Guid id);
        public List<Deposito> RecuperarTodosOsDepositos();
        public Result AtualizarDepositoPorId(Guid id, UpdateDepositoDto depositoDto);
        public Result DeletarDepositoPorId(Guid id);
    }
}
