using SGL.Produto.Core.Domain.Validations;
using SGL.Resource.Domain;
using SGL.Resource.Interfaces;

namespace SGL.Produto.Core.Domain.Entities
{
    public sealed class Produto : Entity, IAggregateRoot
    {
        public Guid FornecedorId { get; private set; }
        public int CategoriaId { get; private set; }
        public string? Descricao { get; private set; }
        public decimal PrecoCompra { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal MargemLucro { get; private set; }
        public int Estoque { get; private set; }
        public bool Situacao { get; private set; }
        public Categoria? Categoria { get; private set; }

        public Produto() { }

        public Produto(
            Guid fornecedor,
            int categoriaId,
            string? descricao,
            decimal precoCompra,
            decimal precoVenda,
            decimal margemLucro,
            int estoque)
        {
            FornecedorId = fornecedor;
            CategoriaId = categoriaId;
            Descricao = descricao;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
            MargemLucro = margemLucro;
            Estoque = estoque;

            Ativo();

            IsValid();
        }

        public void Ativo() => Situacao = true;

        public void Inativo() => Situacao = false;

        public void ReporEstoque(int estoque)
        {
            Estoque += estoque;
        }

        public void DebitarStock(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            Estoque -= quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return Estoque >= quantidade;
        }
        public override bool IsValid()
        {
            ValidationResult = new ProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
