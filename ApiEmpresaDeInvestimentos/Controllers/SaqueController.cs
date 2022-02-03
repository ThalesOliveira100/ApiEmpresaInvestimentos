using ApiEmpresaDeInvestimentos.Data.Dtos.Saque;
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
    public class SaqueController : Controller
    {
        private SaqueService _saqueService;

        public SaqueController(SaqueService saqueService)
        {
            _saqueService = saqueService;
        }

        [HttpPost]
        public IActionResult AdicionarSaque([FromBody] CreateSaqueDto saqueDto)
        {
            ReadSaqueDto readDto = _saqueService.AdicionarSaque(saqueDto);

            if (readDto == null) return BadRequest("Valor do saque não pode ser maior que o saldo na conta ou menor do que 0");
            return CreatedAtAction(nameof(RecuperarSaquePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarTodosOsSaques()
        {
            List<ReadSaqueDto> readDto = _saqueService.RecuperarTodosOsSaques();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSaquePorId(Guid id)
        {
            ReadSaqueDto readDto = _saqueService.RecuperarSaquePorId(id);

            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSaquePorId(Guid  id, UpdateSaqueDto saqueDto)
        {
            Result resultado = _saqueService.AtualizarSaquePorId(id, saqueDto);

            if (resultado != null)
            {
                if (resultado.IsFailed) return BadRequest(resultado.Reasons);
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSaquePorId(Guid id)
        {
            Result resultado = _saqueService.DeletarSaquePorId(id);

            if (resultado.IsFailed) return BadRequest(resultado.Reasons);
            return NoContent();
        }
    }
}
