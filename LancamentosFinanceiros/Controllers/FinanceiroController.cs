using AutoMapper;
using LancamentosFinanceiros.Data.DTO;
using LancamentosFinanceiros.Dominio.Dominio;
using LancamentosFinanceiros.Service.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LancamentosFinanceiros.Dominio.Exceptions;

namespace LancamentosFinanceiros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceiroController : ControllerBase
    {
        private readonly IFinanceiroService _financeiroService;
        private readonly IMapper _mapper;

        public FinanceiroController(IFinanceiroService financeiroService, IMapper mapper)
        {
            _financeiroService = financeiroService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AdicionarFinanceiro")]
        public async Task<IActionResult> AdicionarFinanceiro([FromBody] Financeiro financeiro)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(financeiro.Tipo_pagamento) ||
                    string.IsNullOrWhiteSpace(financeiro.Descricao) ||
                    string.IsNullOrWhiteSpace(financeiro.Banco) ||
                    string.IsNullOrWhiteSpace(financeiro.Tipo_de_conta) ||
                    string.IsNullOrWhiteSpace(financeiro.Cpf_cnpj))
                {
                    return BadRequest("Campos de texto não podem ser vazios ou conter apenas espaços.");
                }

                decimal saldoAtual = await _financeiroService.ObterSaldoPorContaAsync(financeiro.Banco, financeiro.Tipo_de_conta, financeiro.Cpf_cnpj);

                decimal novoSaldo = saldoAtual - financeiro.Valor_lancamento;

                // Permite lançamentos futuros
                if (financeiro.Data_Lancamento.Date < DateTime.Today)
                {
                    throw new RegraDeNegocioException("Não é permitido lançar em datas passadas.");
                }

                // 3. Verificar limite
                if (novoSaldo < -20000.00m)
                {
                    return BadRequest("Operação não permitida: o saldo não pode ultrapassar R$ 20.000,00 negativos.");
                }

                var resultado = await _financeiroService.Adicionar(financeiro);

                FinanceiroDTO financeiroDTO = new FinanceiroDTO();
                financeiroDTO.Data_Lancamento = financeiro.Data_Lancamento;
                financeiroDTO.Tipo_pagamento = financeiro.Tipo_pagamento;
                financeiroDTO.Descricao = financeiro.Descricao;
                financeiroDTO.Banco = financeiro.Banco;
                financeiroDTO.Tipo_de_conta = financeiro.Tipo_de_conta;
                financeiroDTO.Cpf_cnpj = financeiro.Cpf_cnpj;
                financeiroDTO.Valor_lancamento = financeiro.Valor_lancamento;

                return Ok(resultado);
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("ListarFinanceiros")]
        public async Task<List<Financeiro>> ListarFinanceiros()
        {
            return await _financeiroService.ListarFinanceiros();
        }
    }
}
