using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGL.ContasReceber.Core.Domain.Enuns;

namespace SGL.ContasReceber.Infrastructure.Mappings
{
    public class ContasReceberMapping : IEntityTypeConfiguration<Core.Domain.Entities.ContasReceber>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Entities.ContasReceber> builder)
        {
            builder.ToTable("ContasReceber");

            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.ClienteId)
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
