using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Deposito;
using ApiEmpresaDeInvestimentos.Models;
using ApiEmpresaDeInvestimentos.Repositories.Interfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Repositories
{
    public class DepositoRepository : IDepositoRepository
    {
        AppDbContext _context;

        public DepositoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SalvarAlteracoes()
        {
            _context.SaveChanges();
        }

        public Result AdicionarDeposito(Deposito deposito)
        {
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == deposito.ContaDestinoId);

            if (conta == null)
            {
                return Result.Fail("Conta não encontrada");
            }

            conta.Saldo += deposito.Valor;
            _context.Depositos.Add(deposito);
            SalvarAlteracoes();

            return Result.Ok();
        }

        public Deposito RecuperarDepositoPorId(Guid id)
        {
            return _context.Depositos.FirstOrDefault(deposito => deposito.Id == id);
        }

        public List<Deposito> RecuperarTodosOsDepositos()
        {
            return _context.Depositos.ToList();
        }

        public Result AtualizarDepositoPorId(Guid id, UpdateDepositoDto depositoDto)
        {
            Deposito deposito = RecuperarDepositoPorId(id);
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == deposito.ContaDestinoId);

            if (conta == null)
            {
                return Result.Fail("Conta não encontrada");
            }
            conta.Saldo -= deposito.Valor;
            conta.Saldo += depositoDto.Valor;

            return Result.Ok();
        }

        public Result DeletarDepositoPorId(Guid id)
        {
            Deposito deposito = _context.Depositos.FirstOrDefault(deposito => deposito.Id == id);

            if (deposito == null)
            {
                return Result.Fail("Deposito não encontrado");
            }

            // Remove o saldo da conta onde o deposito foi destinado e exclui o registro do deposito.
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == deposito.ContaDestinoId);

            if (conta == null)
            {
                return Result.Fail("Conta não encontrada");
            }
            conta.Saldo -= deposito.Valor;
            _context.Remove(deposito);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
