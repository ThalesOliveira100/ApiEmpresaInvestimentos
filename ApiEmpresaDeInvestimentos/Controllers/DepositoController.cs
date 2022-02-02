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
        public IActionResult AdicionaDeposito([FromBody] CreateDepositoDto depositoDto)
        {
            ReadDepositoDto readDto = _depositoService.AdicionaDeposito(depositoDto);

            return CreatedAtAction(nameof(RecuperaDeposito), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaDeposito()
        {
            List<ReadDepositoDto> readDto = _depositoService.RecuperaDeposito();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaDeposito(int id)
        {
            ReadDepositoDto readDto = _depositoService.RecuperaDeposito(id);

            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaDeposito(int id, UpdateDepositoDto depositoDto)
        {
            Result resultado = _depositoService.AtualizaDeposito(id, depositoDto);

            if (resultado.IsFailed) return NotFound(resultado.Errors);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaDeposito(int id)
        {
            Result resultado = _depositoService.DeletaDeposito(id);

            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
