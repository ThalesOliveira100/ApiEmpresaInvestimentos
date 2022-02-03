using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Cliente;
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
    public class ClienteService
    {
        private IMapper _mapper;
        private ClienteRepository _clienteRepository;

        public ClienteService(IMapper mapper, ClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public ReadClienteDto AdicionarCliente(CreateClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto);
            _clienteRepository.AdicionarCliente(cliente);

            return _mapper.Map<ReadClienteDto>(cliente);
        }

        public List<ReadClienteDto> RecuperarTodosOsClientes()
        {
            List<Cliente> clientes = _clienteRepository.RecuperarTodosOsClientes();

            return _mapper.Map<List<ReadClienteDto>>(clientes);
        }

        public ReadClienteDto RecuperarClientePorId(Guid id)
        {
            Cliente cliente = _clienteRepository.RecuperarClientePorId(id);

            return _mapper.Map<ReadClienteDto>(cliente);
        }

        public Result AtualizarClientePorId(Guid id, UpdateClienteDto clienteDto)
        {
            Cliente cliente = _clienteRepository.RecuperarClientePorId(id);
            if (cliente == null)
            {
                return Result.Fail("Cliente não encontrado");
            }
            _mapper.Map(clienteDto, cliente);
            _clienteRepository.SalvaAlteracoes();

            return Result.Ok();
        }

        public Result DeletarClientePorId(Guid id)
        {
            return _clienteRepository.DeletarClientePorId(id);
        }
    }
}
