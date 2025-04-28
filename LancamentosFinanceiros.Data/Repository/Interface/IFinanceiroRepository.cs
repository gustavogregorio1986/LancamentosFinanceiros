using LancamentosFinanceiros.Data.DTO;
using LancamentosFinanceiros.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentosFinanceiros.Data.Repository.Interface
{
    public interface IFinanceiroRepository
    {
        Task<Financeiro> Adicionar(Financeiro financeiro);

        Task<decimal> ObterSaldoPorContaAsync(string banco, string tipoConta, string cpfCnpj);


        Task<List<Financeiro>> ListarFinanceiros();

        Task<decimal> ObterTotalLancamentosDiaAsync(DateTime data, string banco, string tipoConta, string cpfCnpj);

        Task<Financeiro> AtualizarAsync(Guid id, FinanceiroDTO financeiroDTO);

        Task<Financeiro> ObterPorIdAsync(Guid id);
    }
}
