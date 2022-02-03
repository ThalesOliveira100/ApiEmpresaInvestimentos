using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Saque;
using ApiEmpresaDeInvestimentos.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Repositorys
{
    public class SaqueRepository
    {
        private AppDbContext _context;

        public SaqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SalvarAlteracoes()
        {
            _context.SaveChanges();
        }

        public Result AdicionarSaque(Saque saque)
        {
            if (saque.Valor <= 0)
            {
                return Result.Fail("O valor do saque deve ser maior que 0");
            }

            Conta conta = _context.Contas.FirstOrDefault(conta => saque.ContaId == conta.Id);

            if (conta.Saldo < saque.Valor)
            {
                return Result.Fail("O valor do saque não pode ser maior que o valor da conta");
            }
            conta.Saldo -= saque.Valor;
            _context.Saques.Add(saque);
            _context.SaveChanges();

            return Result.Ok();
        }

        public List<Saque> RecuperarTodosOsSaques()
        {
            return _context.Saques.ToList();
        }

        public Saque RecuperarSaquePorId(Guid id)
        {
            return _context.Saques.FirstOrDefault(saque => saque.Id == id);
        }

        public Result AtualizarSaquePorId(Guid id, UpdateSaqueDto saqueDto)
        {
            var saque = RecuperarSaquePorId(id);
            var conta = _context.Contas.FirstOrDefault(conta => saque.ContaId == conta.Id);

            if (conta == null) return Result.Fail("Conta não encontrada");

            if (saqueDto.Valor > conta.Saldo)
            {
                return Result.Fail("O valor do saque não pode ser maior do que o saldo não conta");
            }
            conta.Saldo += saque.Valor;
            conta.Saldo -= saqueDto.Valor;

            return Result.Ok();
        }

        public Result DeletarSaquePorId(Guid id)
        {
            var saque = RecuperarSaquePorId(id);

            if (saque == null)
            {
                Result.Fail("Saque não encontrado");
            }

            // Devolve o saldo da conta onde o saque foi realizado e exclui o registro do saque.
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == saque.ContaId);

            if (conta == null)
            {
                return Result.Fail("Conta não encontrada");
            }
            
            conta.Saldo += saque.Valor;
            _context.Remove(saque);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
