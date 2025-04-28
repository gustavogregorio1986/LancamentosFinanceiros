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

        public async Task<decimal> ObterSaldoPorContaAsync(string banco, string tipoConta, string cpfCnpj)
        {
            var hoje = DateTime.Today;
            Console.WriteLine($"Buscando lançamentos do dia {hoje.ToShortDateString()} para Banco: {banco}, Tipo de Conta: {tipoConta}, Cpf/Cnpj: {cpfCnpj}");

            var saldo = await _db.Financeiros
                 .Where(f => f.Banco == banco &&
                             f.Tipo_de_conta == tipoConta &&
                             f.Cpf_cnpj == cpfCnpj &&
                             f.Data_Lancamento.Date == hoje)
                 .SumAsync(f => (decimal?)f.Valor_lancamento) ?? 0m;

            Console.WriteLine($"Saldo total encontrado: {saldo}");
            return saldo;

        }

        public async Task<decimal> ObterTotalLancamentosDiaAsync(DateTime data, string banco, string tipoConta, string cpfCnpj)
        {
            var total = await _db.Financeiros
    .Where(f => f.Data_Lancamento.Date == data.Date &&  // Ignorando hora
                f.Banco == banco &&
                f.Tipo_de_conta == tipoConta &&
                f.Cpf_cnpj == cpfCnpj)
    .SumAsync(f => (decimal?)f.Valor_lancamento) ?? 0m;

            return total;
        }
    }
}
