using ApiEmpresaDeInvestimentos.Data.Dtos.Saque;
using ApiEmpresaDeInvestimentos.Models;
using ApiEmpresaDeInvestimentos.Repositories;
using ApiEmpresaDeInvestimentos.Services.Interfaces;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Services
{
    public class SaqueService : ISaqueService
    {
        private IMapper _mapper;
        private SaqueRepository _saqueRepository;

        public SaqueService(IMapper mapper, SaqueRepository saqueRepository)
        {
            _mapper = mapper;
            _saqueRepository = saqueRepository;
        }

        public ReadSaqueDto AdicionarSaque(CreateSaqueDto saqueDto)
        {
            var saque = _mapper.Map<Saque>(saqueDto);
            var resultado = _saqueRepository.AdicionarSaque(saque);
            
            // Aqui retorna null caso dê alguma falha no saque, *Procurar melhor maneira de resolver
            if (resultado.IsFailed) return null;

            return _mapper.Map<ReadSaqueDto>(saque);
        }

        public List<ReadSaqueDto> RecuperarTodosOsSaques()
        {
            List<Saque> saques = _saqueRepository.RecuperarTodosOsSaques();

           return _mapper.Map<List<ReadSaqueDto>>(saques);
        }

        public ReadSaqueDto RecuperarSaquePorId(Guid id)
        {
            var saque = _saqueRepository.RecuperarSaquePorId(id);

            return _mapper.Map<ReadSaqueDto>(saque);
        }

        public Result AtualizarSaquePorId(Guid id, UpdateSaqueDto saqueDto)
        {
            var saque = _saqueRepository.RecuperarSaquePorId(id);

            if (saque == null) 
            {
                Result.Fail("Saque não encontrado");
            } 

            Result resultado = _saqueRepository.AtualizarSaquePorId(id, saqueDto);
            
            if (resultado.IsFailed) return resultado;

            _mapper.Map(saqueDto, saque);
            _saqueRepository.SalvarAlteracoes();

            return Result.Ok();
        }

        public Result DeletarSaquePorId(Guid id)
        {
            Result resultado = _saqueRepository.DeletarSaquePorId(id);

            if (resultado.IsFailed) return resultado;

            return Result.Ok();
        }
    }
}
