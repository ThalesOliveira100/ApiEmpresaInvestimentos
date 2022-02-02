using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Deposito;
using ApiEmpresaDeInvestimentos.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Services
{
    public class DepositoService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public DepositoService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadDepositoDto AdicionaDeposito(CreateDepositoDto depositoDto)
        {
            Depositos deposito = _mapper.Map<Depositos>(depositoDto);
            Contas conta = _context.Contas.FirstOrDefault(conta => conta.Id == deposito.ContaDestinoId);

            if (conta != null)
            {
                conta.Saldo += deposito.Valor;
                _context.Depositos.Add(deposito);
                _context.SaveChanges();

                return _mapper.Map<ReadDepositoDto>(deposito);
            }
            return null;
        }

        public ReadDepositoDto RecuperaDeposito(int id)
        {
            Depositos deposito = _context.Depositos.FirstOrDefault(deposito => deposito.Id == id);

            return _mapper.Map<ReadDepositoDto>(deposito);
        }

        public List<ReadDepositoDto> RecuperaDeposito()
        {
            List<Depositos> depositos = _context.Depositos.ToList();

            return _mapper.Map<List<ReadDepositoDto>>(depositos);
        }

        public Result AtualizaDeposito(int id, [FromBody]UpdateDepositoDto depositoDto)
        {
            Depositos deposito = _context.Depositos.FirstOrDefault(deposito => deposito.Id == id);

            if (deposito == null)
            {
                return Result.Fail("Deposito não encontrado");
            }

            Contas conta = _context.Contas.FirstOrDefault(conta => conta.Id == deposito.ContaDestinoId);

            if (conta != null)
            {
                conta.Saldo -= deposito.Valor;
                conta.Saldo += depositoDto.Valor;
                _mapper.Map(depositoDto, deposito);
                _context.SaveChanges();

                return Result.Ok();
            }

            return Result.Fail("Conta não encontrada");
        }

        public Result DeletaDeposito(int id)
        {
            Depositos deposito = _context.Depositos.FirstOrDefault(deposito => deposito.Id == id);

            if (deposito == null)
            {
                return Result.Fail("Deposito não encontrado");
            }

            // Remove o saldo da conta onde o deposito foi destinado e exclui o registro do deposito.
            Contas conta = _context.Contas.FirstOrDefault(conta => conta.Id == deposito.ContaDestinoId);
            
            if(conta != null)
            {
                conta.Saldo -= deposito.Valor;
            }
            
            _context.Remove(deposito);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
