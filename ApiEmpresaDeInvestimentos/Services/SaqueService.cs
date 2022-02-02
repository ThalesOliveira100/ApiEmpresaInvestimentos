using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Saque;
using ApiEmpresaDeInvestimentos.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Services
{
    public class SaqueService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public SaqueService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadSaqueDto AdicionaSaque(CreateSaqueDto saqueDto)
        {
            Saques saque = _mapper.Map<Saques>(saqueDto);

            if (saque.Valor <= 0)
            {
                return null;
            }

            Contas conta = _context.Contas.FirstOrDefault(conta => saque.ContaId == conta.Id);

            if (conta.Saldo < saque.Valor)
            {
                return null;
            }

            conta.Saldo -= saque.Valor;
            _context.Saques.Add(saque);
            _context.SaveChanges();

            return _mapper.Map<ReadSaqueDto>(saque);
 
        }

        public List<ReadSaqueDto> RecuperaSaque()
        {
            List<Saques> saques = _context.Saques.ToList();

           return _mapper.Map<List<ReadSaqueDto>>(saques);
        }

        public ReadSaqueDto RecuperaSaque(int id)
        {
            Saques saque = _context.Saques.FirstOrDefault(saque => saque.Id == id);

            return _mapper.Map<ReadSaqueDto>(saque);
        }

        public Result AtualizaSaque(int id, UpdateSaqueDto saqueDto)
        {
            Saques saque = _context.Saques.FirstOrDefault(saque => saque.Id == id);

            if (saque != null)
            {
                Contas conta = _context.Contas.FirstOrDefault(conta => saque.ContaId == conta.Id);

                if (conta != null)
                {
                    if (saqueDto.Valor > conta.Saldo)
                    {
                        return Result.Fail("O valor do saque não pode ser maior do que o saldo não conta");
                    }

                    conta.Saldo += saque.Valor;
                    conta.Saldo -= saqueDto.Valor;
                    _mapper.Map(saqueDto, saque);
                    _context.SaveChanges();

                    return Result.Ok();
                }
            }

            return null;
        }

        public Result DeletaSaque(int id)
        {
            Saques saque = _context.Saques.FirstOrDefault(saque => saque.Id == id);

            if (saque == null)
            {
                Result.Fail("Saque não encontrado");
            }

            // Devolve o saldo da conta onde o saque foi realizado e exclui o registro do saque.
            Contas conta = _context.Contas.FirstOrDefault(conta => conta.Id == saque.ContaId);

            if (conta != null)
            {
                conta.Saldo += saque.Valor;
            }

            _context.Remove(saque);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
