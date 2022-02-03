using ApiEmpresaDeInvestimentos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpresaDeInvestimentos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base (opt)
        {

        }

        public DbSet<Conta> Contas { get; set; } 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Saque> Saques { get; set; }
    }
}
