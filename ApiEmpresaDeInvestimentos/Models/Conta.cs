﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Models
{
    public class Conta
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo clienteId é obrigatório")]
        public Guid ClienteId { get; set; }
        [Required(ErrorMessage = "O campo numero é obrigatório")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "O campo agencia é obrigatório")]
        public string Agencia { get; set; }
        [Range(0, 1000000000, ErrorMessage = "O valor do saldo não pode ser inferior a 0 e nao pode ultrapassar 1.000.000.000")]
        public double Saldo { get; set; }
    }
}
