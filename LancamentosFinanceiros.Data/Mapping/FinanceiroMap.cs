using LancamentosFinanceiros.Dominio.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentosFinanceiros.Data.Mapping
{
    public class FinanceiroMap : IEntityTypeConfiguration<Financeiro>
    {
        public void Configure(EntityTypeBuilder<Financeiro> builder)
        {
            builder.ToTable("tb_Financeiro");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Data_Lancamento)
                .IsRequired()
                .HasColumnName("DATETIME");

            builder.Property(x => x.Tipo_de_conta)
               .IsRequired()
               .HasColumnName("NVARCHAR(50)");

            builder.Property(x => x.Banco)
               .IsRequired()
               .HasColumnName("NVARCHAR(40)");

            builder.Property(x => x.Tipo_de_conta)
               .IsRequired()
               .HasColumnName("NVARCHAR(40)");

            builder.Property(x => x.Cpf_cnpj)
               .IsRequired()
               .HasColumnName("NVARCHAR(15)");

            builder.Property(x => x.Valor_lancamento)
               .IsRequired()
               .HasColumnName("DECIMAL(10,2)");
        }
    }
}
