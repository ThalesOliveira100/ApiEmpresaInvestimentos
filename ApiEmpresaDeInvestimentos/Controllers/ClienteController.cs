using ApiEmpresaDeInvestimentos.Data.Dtos.Cliente;
using ApiEmpresaDeInvestimentos.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult AdicionarCliente([FromBody]CreateClienteDto clienteDto)
        {
            ReadClienteDto readDto = _clienteService.AdicionarCliente(clienteDto);

            return CreatedAtAction(nameof(RecuperarClientePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarTodosOsClientes()
        {
            List<ReadClienteDto> readDto = _clienteService.RecuperarTodosOsClientes();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarClientePorId(Guid id)
        {
            ReadClienteDto readDto = _clienteService.RecuperarClientePorId(id);

            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarClientePorId(Guid id, [FromBody] UpdateClienteDto clienteDto)
        {
            Result resultado = _clienteService.AtualizarClientePorId(id, clienteDto);

            if (resultado.IsFailed) return BadRequest(resultado.Reasons);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarClientePorId(Guid id)
        {
            Result resultado = _clienteService.DeletarClientePorId(id);

            if (resultado.IsFailed) return BadRequest(resultado.Reasons);
            return NoContent();
        }
    }
}
