using ApiEmpresaDeInvestimentos.Data.Dtos.Deposito;
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
    public class DepositoController : Controller
    {
        private DepositoService _depositoService;

        public DepositoController(DepositoService depositoService)
        {
            _depositoService = depositoService;
        }

        [HttpPost]
        public IActionResult AdicionarDeposito([FromBody] CreateDepositoDto depositoDto)
        {
            ReadDepositoDto readDto = _depositoService.AdicionarDeposito(depositoDto);
            if (readDto == null)
            {
                return BadRequest("Conta não encontrada");
            }

            return CreatedAtAction(nameof(RecuperarDepositoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarTodosOsDeposito()
        {
            List<ReadDepositoDto> readDto = _depositoService.RecuperarTodosOsDepositos();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarDepositoPorId(Guid id)
        {
            ReadDepositoDto readDto = _depositoService.RecuperarDepositoPorId(id);

            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarDepositoPorId(Guid id, UpdateDepositoDto depositoDto)
        {
            Result resultado = _depositoService.AtualizarDepositoPorId(id, depositoDto);

            if (resultado.IsFailed) return NotFound(resultado.Reasons);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarDepositoPorId(Guid id)
        {
            Result resultado = _depositoService.DeletarDepositoPorId(id);

            if (resultado.IsFailed) return NotFound(resultado.Reasons);
            return NoContent();
        }
    }
}
