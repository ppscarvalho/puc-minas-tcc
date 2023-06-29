using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SGL.Produto.Infrastructure.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Core.Domain.Entities.Produto>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Entities.Produto> builder)
        {
            builder.ToTable("Produto");

            builder.Property(c => c.FornecedorId)
                .IsRequired();

            builder.Property(c => c.CategoriaId)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.PrecoCompra)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(c => c.PrecoVenda)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(c => c.MargemLucro)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(c => c.Estoque)
                .IsRequired();

            builder.Property(c => c.Situacao)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
