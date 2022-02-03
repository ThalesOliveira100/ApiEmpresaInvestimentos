﻿using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Cliente;
using ApiEmpresaDeInvestimentos.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Repositorys
{
    public class ClienteRepository
    {
        private AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SalvaAlteracoes()
        {
            _context.SaveChanges();
        }

        public void AdicionarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            SalvaAlteracoes();
        }

        public List<Cliente> RecuperarTodosOsClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente RecuperarClientePorId(Guid id)
        {
            return _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        }

        public Result DeletarClientePorId(Guid id)
        {
            Cliente cliente = RecuperarClientePorId(id);

            if (cliente == null) return Result.Fail("Cliente não encontrado");

            // Verifica se há uma conta com o ClienteId no banco de dados, se tiver ela tambem é excluida.
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.ClienteId == cliente.Id);
            if (conta != null)
            {
                _context.Remove(conta);
            }

            _context.Remove(cliente);
            SalvaAlteracoes();

            return Result.Ok();
        }
    }
}
