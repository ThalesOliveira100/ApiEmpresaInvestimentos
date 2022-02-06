using ApiEmpresaDeInvestimentos.Data.Dtos.Saque;
using ApiEmpresaDeInvestimentos.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Repositories.Interfaces
{
    interface ISaqueRepository
    {
        public void SalvarAlteracoes();
        public Result AdicionarSaque(Saque saque);
        public List<Saque> RecuperarTodosOsSaques();
        public Saque RecuperarSaquePorId(Guid id);
        public Result AtualizarSaquePorId(Guid id, UpdateSaqueDto saqueDto);
        public Result DeletarSaquePorId(Guid id);
    }
}
