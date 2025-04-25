using LancamentosFinanceiros.Data.Context;
using LancamentosFinanceiros.Data.Repository.Interface;
using LancamentosFinanceiros.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentosFinanceiros.Data.Repository
{
    public class FinanceiroRepository : IFinanceiroRepository
    {
        private readonly DbContexto _db;

        public FinanceiroRepository(DbContexto db)
        {
            _db = db;
        }

        public async Task<Financeiro> Adicionar(Financeiro financeiro)
        {
            _db.Financeiros.AddAsync(financeiro);
            await _db.SaveChangesAsync();
            return financeiro;
        }

        public async Task<List<Financeiro>> ListarFinanceiros()
        {
            var trintaDiasAtras = DateTime.Now.AddDays(-30);
            return await _db.Financeiros
                .Where(x => x.Data_Lancamento >= trintaDiasAtras)
                .ToListAsync();

        }
    }
}
