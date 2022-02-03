using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Repositorys
{
    public class ContaRepository
    {
        private AppDbContext _context;

        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SalvarAlteracoes()
        {
            _context.SaveChanges();
        }

        public void AdicionarConta(Conta conta)
        {
            _context.Contas.Add(conta);
            SalvarAlteracoes();
        }

        public List<Conta> RecuperarTodasAsContas()
        {
            return _context.Contas.ToList();
        }

        public Conta RecuperarContaPorId(Guid id)
        {
            return _context.Contas.FirstOrDefault(conta => conta.Id == id);
        }

        public Result DeletarContaPorId(Guid id)
        {
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);

            if (conta == null) return Result.Fail("Conta não encontrada");

            _context.Remove(conta);
            SalvarAlteracoes();

            return Result.Ok();
        }
    }
}
