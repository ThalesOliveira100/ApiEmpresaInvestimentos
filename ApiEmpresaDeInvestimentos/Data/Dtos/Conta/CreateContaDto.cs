using ApiEmpresaDeInvestimentos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Data.Dtos.Conta
{
    public class CreateContaDto
    {
        [Required(ErrorMessage = "O numero é obrigatório")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "O campo agencia é obrigatório")]
        public string Agencia { get; set; }
        [Required(ErrorMessage = "O campo titular é obrigatório")]
        public Guid ClienteId { get; set; }

    }
}
