using ApiEmpresaDeInvestimentos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Data.Dtos.Conta
{
    public class ReadContaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo número é obrigatório")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "O campo agência é obrigatório")]
        public string Agencia { get; set; }
        [Required(ErrorMessage = "O campo ClienteId é obrigatório")]
        public int ClienteId { get; set; }
        public double Saldo { get; set; }
    }
}
