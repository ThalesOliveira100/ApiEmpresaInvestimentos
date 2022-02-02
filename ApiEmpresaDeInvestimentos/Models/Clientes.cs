using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Models
{
    public class Clientes
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo cpf é obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage ="O campo telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }

    }
}
