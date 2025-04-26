using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentosFinanceiros.Data.DTO
{
    public class FinanceiroDTO
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
    }
}
