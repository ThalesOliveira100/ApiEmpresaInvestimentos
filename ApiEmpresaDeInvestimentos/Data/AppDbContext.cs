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

        public DbSet<Contas> Contas { get; set; } 
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Depositos> Depositos { get; set; }
        public DbSet<Saques> Saques { get; set; }
    }
}
