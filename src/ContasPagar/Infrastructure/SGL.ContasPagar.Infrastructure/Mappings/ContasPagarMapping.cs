using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGL.ContasPagar.Core.Domain.Enuns;

namespace SGL.ContasPagar.Infrastructure.Mappings
{
    public class ContasPagarMapping : IEntityTypeConfiguration<Core.Domain.Entities.ContasPagar>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Entities.ContasPagar> builder)
        {
            builder.ToTable("ContasPagar");

            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.FornecedorId)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.DataVencimento)
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.Situacao)
                .HasConversion(
                    to => to.ToString(),
                    from => (ESituacao)Enum.Parse(typeof(ESituacao), from))
                .IsRequired();
        }
    }
}
