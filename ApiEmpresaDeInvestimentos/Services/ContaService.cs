using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Conta;
using ApiEmpresaDeInvestimentos.Models;
using ApiEmpresaDeInvestimentos.Repositorys;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Services
{
    public class ContaService
    {
        private IMapper _mapper;
        private ContaRepository _contaRepository;

        public ContaService(ContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        public ReadContaDto AdicionarConta(CreateContaDto contaDto)
        {
            Conta conta = _mapper.Map<Conta>(contaDto);
            _contaRepository.AdicionarConta(conta);

            return _mapper.Map<ReadContaDto>(conta);
        }

        public List<ReadContaDto> RecuperarTodasAsContas()
        {
            List<Conta> contas = _contaRepository.RecuperarTodasAsContas();
            
            return _mapper.Map<List<ReadContaDto>>(contas);
        }

        public ReadContaDto RecuperarContaPorId(Guid id)
        {
            Conta conta = _contaRepository.RecuperarContaPorId(id);
            
            return _mapper.Map<ReadContaDto>(conta);
        }

        public Result AtualizarContaPorId(Guid id, UpdateContaDto contaDto)
        {
            Conta conta = _contaRepository.RecuperarContaPorId(id);
            if (conta == null)
            {
                return Result.Fail("Conta não encontrada");
            }
            _mapper.Map(contaDto, conta);
            _contaRepository.SalvarAlteracoes();

            return Result.Ok();
        }

        public Result DeletarContaPorId(Guid id)
        {
            return _contaRepository.DeletarContaPorId(id);
        }
    }
}
