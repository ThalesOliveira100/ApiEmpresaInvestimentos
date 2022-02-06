using ApiEmpresaDeInvestimentos.Data.Dtos.Saque;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Services.Interfaces
{
    public interface ISaqueService
    {
        public ReadSaqueDto AdicionarSaque(CreateSaqueDto saqueDto);
        public ReadSaqueDto RecuperarSaquePorId(Guid id);
        public List<ReadSaqueDto> RecuperarTodosOsSaques();
        public Result AtualizarSaquePorId(Guid id, UpdateSaqueDto saqueDto);
        public Result DeletarSaquePorId(Guid id);
    }
}
