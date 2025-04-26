using AutoMapper;
using LancamentosFinanceiros.Data.DTO;
using LancamentosFinanceiros.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentosFinanceiros.Data.AutoMapper
{
    public class FinanceiroMapping : Profile
    { 
        public FinanceiroMapping()
        {
            CreateMap<Financeiro, FinanceiroDTO>();
        }
    }
}
