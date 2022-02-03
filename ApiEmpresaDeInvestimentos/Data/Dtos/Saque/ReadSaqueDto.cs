using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Data.Dtos.Saque
{
    public class ReadSaqueDto
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Range(20, 1000000, ErrorMessage = "O valor do Saque deve ser maior que 20 e não pode exceder 1.000.000")]
        public double Valor { get; set; }
        [Required]
        public Guid ContaId { get; set; }
        public string Descricao { get; set; }
    }
}
