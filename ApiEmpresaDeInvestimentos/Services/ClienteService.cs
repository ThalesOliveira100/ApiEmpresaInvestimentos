using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Cliente;
using ApiEmpresaDeInvestimentos.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Services
{
    public class ClienteService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public ClienteService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadClienteDto AdicionaCliente(CreateClienteDto clienteDto)
        {
            Clientes cliente = _mapper.Map<Clientes>(clienteDto);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return _mapper.Map<ReadClienteDto>(cliente);
        }

        public List<ReadClienteDto> RecuperaCliente()
        {
            List<Clientes> clientes = _context.Clientes.ToList();

            return _mapper.Map<List<ReadClienteDto>>(clientes);
        }

        public ReadClienteDto RecuperaCliente(int id)
        {
            Clientes cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            return _mapper.Map<ReadClienteDto>(cliente);
        }

        public Result AtualizaCliente(int id, UpdateClienteDto clienteDto)
        {
            Clientes cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            
            if (clienteDto == null)
            {
                return Result.Fail("Cliente não encontrado");
            }
            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaCliente(int id)
        {
            Clientes cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            if (cliente == null) return Result.Fail("Cliente não encontrado");

            // Verifica se há uma conta com o clienteId no banco de dados, se tiver ela tambem é excluida.
            Contas conta = _context.Contas.FirstOrDefault(conta => conta.ClienteId == cliente.Id);
            if (conta != null)
            {
                _context.Remove(conta);
            }

            _context.Remove(cliente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
