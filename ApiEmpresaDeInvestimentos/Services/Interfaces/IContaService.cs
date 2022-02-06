using ApiEmpresaDeInvestimentos.Data.Dtos.Conta;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Services.Interfaces
{
    interface IContaService
    {
        public ReadContaDto AdicionarConta(CreateContaDto contaDto);
        public List<ReadContaDto> RecuperarTodasAsContas();
        public ReadContaDto RecuperarContaPorId(Guid id);
        public Result AtualizarContaPorId(Guid id, UpdateContaDto contaDto);
        public Result DeletarContaPorId(Guid id);

    }
}
