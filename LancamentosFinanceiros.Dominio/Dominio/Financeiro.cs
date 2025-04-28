using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentosFinanceiros.Dominio.Dominio
{
    public class Financeiro
    {
        public Guid Id { get; set; }

        public DateTime Data_Lancamento { get; set; }

        public string? Tipo_pagamento { get; set; }

        public string? Descricao { get; set; }

        public string? Banco { get; set; }

        public string? Conta { get; set; }

        public string? Tipo_de_conta { get; set; }

        public string? Cpf_cnpj { get; set; }

        public decimal Valor_lancamento { get; set; }

        public Financeiro()
        {
            
        }

        public Financeiro(string banco, string tipoDeConta, string cpfCnpj, DateTime dataLancamento, decimal valorLancamento, string tipoPagamento, string descricao)
        {
            Banco = banco;
            Tipo_de_conta = tipoDeConta;
            Cpf_cnpj = cpfCnpj;
            Data_Lancamento = dataLancamento;
            Valor_lancamento = valorLancamento;
            Tipo_pagamento = tipoPagamento;
            Descricao = descricao;
        }

        // Método para edição
        public void Editar(string banco, string tipoDeConta, string cpfCnpj, DateTime dataLancamento, decimal valorLancamento, string tipoPagamento, string descricao)
        {
            Banco = banco;
            Tipo_de_conta = tipoDeConta;
            Cpf_cnpj = cpfCnpj;
            Data_Lancamento = dataLancamento;
            Valor_lancamento = valorLancamento;
            Tipo_pagamento = tipoPagamento;
            Descricao = descricao;
        }
    }
}
