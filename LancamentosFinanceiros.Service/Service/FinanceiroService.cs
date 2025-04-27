using LancamentosFinanceiros.Data.Repository.Interface;
using LancamentosFinanceiros.Dominio.Dominio;
using LancamentosFinanceiros.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentosFinanceiros.Service.Service
{
    public class FinanceiroService : IFinanceiroService
    {
        private readonly IFinanceiroRepository _financeiroRepository;

        public FinanceiroService(IFinanceiroRepository financeiroRepository)
        {
            _financeiroRepository = financeiroRepository;
        }

        public async Task<Financeiro> Adicionar(Financeiro financeiro)
        {
            // Corrigindo a regra: a data tem que ser dos últimos 30 dias
            if (financeiro.Data_Lancamento < DateTime.Now.AddDays(-30))
            {
                throw new ArgumentException("A data de lançamento deve ser dos últimos 30 dias.");
            }

            return await _financeiroRepository.Adicionar(financeiro);
        }


        public async Task<List<Financeiro>> ListarFinanceiros()
        {
            return await _financeiroRepository
               .ListarFinanceiros();
        }

        public async Task<decimal> ObterSaldoPorContaAsync(string banco, string tipoConta, string cpfCnpj)
        {
            return await _financeiroRepository.ObterSaldoPorContaAsync(banco, tipoConta, cpfCnpj);
        }
    }
}
