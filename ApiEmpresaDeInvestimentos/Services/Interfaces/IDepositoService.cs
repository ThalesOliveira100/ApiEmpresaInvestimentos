using ApiEmpresaDeInvestimentos.Data.Dtos.Deposito;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Services.Interfaces
{
    interface IDepositoService
    {
        public ReadDepositoDto AdicionarDeposito(CreateDepositoDto depositoDto);
        public ReadDepositoDto RecuperarDepositoPorId(Guid id);
        public List<ReadDepositoDto> RecuperarTodosOsDepositos();
        public Result AtualizarDepositoPorId(Guid id, UpdateDepositoDto depositoDto);
        public Result DeletarDepositoPorId(Guid id);
    }
}
