using LancamentosFinanceiros.Data.DTO;
using LancamentosFinanceiros.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentosFinanceiros.Service.Service.Interface
{
    public interface IFinanceiroService
    {
        Task<Financeiro> Adicionar(Financeiro financeiro);

        Task<decimal> ObterSaldoPorContaAsync(string banco, string tipoConta, string cpfCnpj);

        Task<List<Financeiro>> ListarFinanceiros();

        Task<string> ObterTotalLancamentosDiaFormatadoAsync(string banco, string tipoConta, string cpfCnpj);

        Task<FinanceiroDTO> EditarFinanceiroAsync(Guid id, FinanceiroDTO financeiroDto);
    }
}
