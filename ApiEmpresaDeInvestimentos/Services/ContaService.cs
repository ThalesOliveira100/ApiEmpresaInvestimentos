using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Conta;
using ApiEmpresaDeInvestimentos.Models;
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
        private AppDbContext _context;

        public ContaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadContaDto AdicionaConta(CreateContaDto contaDto)
        {
            Contas conta = _mapper.Map<Contas>(contaDto);
            _context.Contas.Add(conta);
            _context.SaveChanges();

            return _mapper.Map<ReadContaDto>(conta);
        }

        public List<ReadContaDto> RecuperaConta()
        {
            List<Contas> contas = _context.Contas.ToList();
            
            return _mapper.Map<List<ReadContaDto>>(contas);
        }

        public ReadContaDto RecuperaConta(int id)
        {
            Contas conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            
            return _mapper.Map<ReadContaDto>(conta);
        }

        public Result AtualizaConta(int id, UpdateContaDto contaDto)
        {
            Contas conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta == null)
            {
                return Result.Fail("Conta não encontrada");
            }
            _mapper.Map(contaDto, conta);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaConta(int id)
        {
            Contas conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta == null)
            {
                return Result.Fail("Conta não encontrada");
            }
            _context.Remove(conta);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
