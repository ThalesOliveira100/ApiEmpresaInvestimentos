using ApiEmpresaDeInvestimentos.Data.Dtos.Deposito;
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
    public class DepositoService : IDepositoService
    {
        private IMapper _mapper;
        private DepositoRepository _depositoRepository;

        public DepositoService(IMapper mapper, DepositoRepository depositoRepository)
        {
            _mapper = mapper;
            _depositoRepository = depositoRepository;
        }

        public ReadDepositoDto AdicionarDeposito(CreateDepositoDto depositoDto)
        {
            Deposito deposito = _mapper.Map<Deposito>(depositoDto);
            Result resultado = _depositoRepository.AdicionarDeposito(deposito);

            if (resultado.IsFailed) return null;

            return _mapper.Map<ReadDepositoDto>(deposito);
        }

        public ReadDepositoDto RecuperarDepositoPorId(Guid id)
        {
            Deposito deposito = _depositoRepository.RecuperarDepositoPorId(id);

            return _mapper.Map<ReadDepositoDto>(deposito);
        }

        public List<ReadDepositoDto> RecuperarTodosOsDepositos()
        {
            List<Deposito> depositos = _depositoRepository.RecuperarTodosOsDepositos();

            return _mapper.Map<List<ReadDepositoDto>>(depositos);
        }

        public Result AtualizarDepositoPorId(Guid id, UpdateDepositoDto depositoDto)
        {
            Deposito deposito = _depositoRepository.RecuperarDepositoPorId(id);

            if (deposito == null)
            {
                return Result.Fail("Deposito não encontrado");
            }

            Result resultado = _depositoRepository.AtualizarDepositoPorId(id, depositoDto);

            if (resultado.IsFailed) return resultado;

            _mapper.Map(depositoDto, deposito);
            _depositoRepository.SalvarAlteracoes();

            return Result.Ok();
        }

        public Result DeletarDepositoPorId(Guid id)
        {
            return _depositoRepository.DeletarDepositoPorId(id);
        }
    }
}
