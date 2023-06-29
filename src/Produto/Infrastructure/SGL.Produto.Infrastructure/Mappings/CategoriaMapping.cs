using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGL.Produto.Core.Domain.Entities;

namespace SGL.Produto.Infrastructure.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired();


            builder.Property(c => c.Descricao).HasMaxLength(250)
                .IsRequired();

            // 1 : N => Categorias : Produtos
            builder.HasMany(c => c.Produto)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
