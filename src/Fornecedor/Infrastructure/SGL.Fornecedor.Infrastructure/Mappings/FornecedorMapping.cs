using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SGL.Fornecedor.Infrastructure.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Core.Domain.Entities.Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Entities.Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.Property(c => c.RazaoSocial)
                 .HasMaxLength(100)
                 .IsRequired();

            builder.Property(c => c.NomeFantasia)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.CNPJ)
                .HasMaxLength(20);

            builder.Property(c => c.InscricaoEstadual)
                .HasMaxLength(100);

            builder.Property(c => c.Celular)
                .HasMaxLength(20);

            builder.OwnsOne(s => s.Email, em =>
            {
                em.Property(c => c.EnderecoEmail)
                .HasColumnName("Email")
                .HasMaxLength(100);
            });

            builder.OwnsOne(c => c.Endereco, cm =>
            {
                cm.Property(c => c.Logradouro)
                .HasColumnName("Logradouro")
                .HasMaxLength(100);

                cm.Property(c => c.Numero)
                .HasColumnName("Numero")
                .HasMaxLength(10);

                cm.Property(c => c.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(100);

                cm.Property(c => c.Bairro)
                .HasColumnName("Bairro")
                .HasMaxLength(60);

                cm.Property(c => c.Cidade)
                .HasColumnName("Cidade")
                .HasMaxLength(60);

                cm.Property(c => c.CEP)
                .HasColumnName("CEP")
                .HasMaxLength(13);

                cm.Property(c => c.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(2);
            });
        }
    }
}
