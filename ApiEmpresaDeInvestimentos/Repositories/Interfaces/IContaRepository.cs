using ApiEmpresaDeInvestimentos.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Repositories.Interfaces
{
    interface IContaRepository
    {
        public void SalvarAlteracoes();
        public void AdicionarConta(Conta conta);
        public List<Conta> RecuperarTodasAsContas();
        public Conta RecuperarContaPorId(Guid id);
        public Result DeletarContaPorId(Guid id);

    }
}
