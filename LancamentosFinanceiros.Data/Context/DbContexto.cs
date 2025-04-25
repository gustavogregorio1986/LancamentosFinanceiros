using LancamentosFinanceiros.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentosFinanceiros.Data.Context
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Financeiro> Financeiros { get; set; }
    }
}
