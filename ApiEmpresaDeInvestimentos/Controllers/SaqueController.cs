﻿using ApiEmpresaDeInvestimentos.Data.Dtos.Saque;
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
        public IActionResult AdicionaSaque([FromBody] CreateSaqueDto saqueDto)
        {
            ReadSaqueDto readDto = _saqueService.AdicionaSaque(saqueDto);

            if (readDto == null) return BadRequest("Valor do saque não pode ser maior que o saldo na conta ou menor do que 0");
            return CreatedAtAction(nameof(RecuperaSaque), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaSaque()
        {
            List<ReadSaqueDto> readDto = _saqueService.RecuperaSaque();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSaque(int id)
        {
            ReadSaqueDto readDto = _saqueService.RecuperaSaque(id);

            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSaque(int id, UpdateSaqueDto saqueDto)
        {
            Result resultado = _saqueService.AtualizaSaque(id, saqueDto);

            if (resultado != null)
            {
                if (resultado.IsFailed) return BadRequest(resultado.Reasons);
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaSaque(int id)
        {
            Result resultado = _saqueService.DeletaSaque(id);

            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
