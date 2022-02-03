using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Models
{
    public class Deposito
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ContaDestinoId { get; set; }
        [Required]
        [Range(10,1000000,ErrorMessage = "O valor do deposito deve ser maior que 10 e não pode exceder 1.000.000")]
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }
}
