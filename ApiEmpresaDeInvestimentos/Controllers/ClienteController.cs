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
        public IActionResult AdicionaCliente([FromBody]CreateClienteDto clienteDto)
        {
            ReadClienteDto readDto = _clienteService.AdicionaCliente(clienteDto);

            return CreatedAtAction(nameof(RecuperaCliente), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCliente()
        {
            List<ReadClienteDto> readDto = _clienteService.RecuperaCliente();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCliente(int id)
        {
            ReadClienteDto readDto = _clienteService.RecuperaCliente(id);

            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            Result resultado = _clienteService.AtualizaCliente(id, clienteDto);

            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(int id)
        {
            Result resultado = _clienteService.DeletaCliente(id);

            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
