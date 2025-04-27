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
    }
}
