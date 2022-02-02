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
        public IActionResult AdicionaConta([FromBody]CreateContaDto contaDto)
        {
            ReadContaDto readDto = _contaService.AdicionaConta(contaDto);

            return CreatedAtAction(nameof(RecuperaConta), new { Id = readDto.Id }, readDto);

        }

        [HttpGet]
        public IActionResult RecuperaConta()
        {
            List<ReadContaDto> readDto = _contaService.RecuperaConta();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaConta(int id)
        {
            ReadContaDto readDto = _contaService.RecuperaConta(id);

            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaConta(int id, [FromBody] UpdateContaDto contaDto)
        {
            Result resultado = _contaService.AtualizaConta(id, contaDto);

            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaConta(int id)
        {
            Result resultado = _contaService.DeletaConta(id);

            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
