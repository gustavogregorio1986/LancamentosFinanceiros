using LancamentosFinanceiros.Data.DTO;
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

        public async Task<FinanceiroDTO> EditarFinanceiroAsync(Guid id, FinanceiroDTO financeiroDto)
        {
            var financeiro = await _financeiroRepository.ObterPorIdAsync(id);

            if (financeiro == null)
            {
                throw new ArgumentException("Financeiro não encontrado.");
            }

            // Atualize os campos com as informações do DTO
            financeiro.Banco = financeiroDto.Banco;
            financeiro.Tipo_de_conta = financeiroDto.Tipo_de_conta;
            financeiro.Cpf_cnpj = financeiroDto.Cpf_cnpj;
            financeiro.Data_Lancamento = financeiroDto.Data_Lancamento;
            financeiro.Valor_lancamento = financeiroDto.Valor_lancamento;
            financeiro.Tipo_pagamento = financeiroDto.Tipo_pagamento;
            financeiro.Descricao = financeiroDto.Descricao;

            // Salva as alterações no banco
            await _financeiroRepository.AtualizarAsync(id, financeiroDto);

            // Retorna o DTO atualizado
            return new FinanceiroDTO
            {
                Banco = financeiro.Banco,
                Tipo_de_conta = financeiro.Tipo_de_conta,
                Cpf_cnpj = financeiro.Cpf_cnpj,
                Data_Lancamento = financeiro.Data_Lancamento,
                Valor_lancamento = financeiro.Valor_lancamento,
                Tipo_pagamento = financeiro.Tipo_pagamento,
                Descricao = financeiro.Descricao
            };
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

        public async Task<string> ObterTotalLancamentosDiaFormatadoAsync(string banco, string tipoConta, string cpfCnpj)
        {
            decimal total = await _financeiroRepository.ObterTotalLancamentosDiaAsync(DateTime.Today, banco, tipoConta, cpfCnpj);

            return total.ToString("C", new System.Globalization.CultureInfo("pt-BR"));
        }
    }
}
