using ApiEmpresaDeInvestimentos.Data;
using ApiEmpresaDeInvestimentos.Data.Dtos.Conta;
using ApiEmpresaDeInvestimentos.Models;
using ApiEmpresaDeInvestimentos.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private ContaService _contaService;

        public ContaController(ContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost]
        public IActionResult AdicionarConta([FromBody]CreateContaDto contaDto)
        {
            ReadContaDto readDto = _contaService.AdicionarConta(contaDto);

            return CreatedAtAction(nameof(RecuperarContaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarTodasAsContas()
        {
            List<ReadContaDto> readDto = _contaService.RecuperarTodasAsContas();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarContaPorId(Guid id)
        {
            ReadContaDto readDto = _contaService.RecuperarContaPorId(id);

            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarContaPorId(Guid id, [FromBody] UpdateContaDto contaDto)
        {
            Result resultado = _contaService.AtualizarContaPorId(id, contaDto);

            if (resultado.IsFailed) return BadRequest(resultado.Reasons);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarContaPorId(Guid id)
        {
            Result resultado = _contaService.DeletarContaPorId(id);

            if (resultado.IsFailed) return BadRequest(resultado.Reasons);
            return NoContent();
        }

    }
}
