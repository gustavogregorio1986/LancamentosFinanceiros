using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LancamentosFinanceiros.Data.Migrations
{
    public partial class CriarTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financeiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data_Lancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo_pagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_de_conta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf_cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor_lancamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financeiros");
        }
    }
}
