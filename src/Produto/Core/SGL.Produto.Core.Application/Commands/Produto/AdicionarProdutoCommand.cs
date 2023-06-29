using SGL.Produto.Core.Application.Commands.Produto.Validation;
using SGL.Resource.Messagens;

namespace SGL.Produto.Core.Application.Commands.Produto
{
    public class AdicionarProdutoCommand : CommandHandler
    {
        public Guid FornecedorId { get; private set; }
        public int CategoriaId { get; private set; }
        public string? Descricao { get; private set; }
        public decimal PrecoCompra { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal MargemLucro { get; private set; }
        public int Estoque { get; private set; }

        public AdicionarProdutoCommand() { }

        public AdicionarProdutoCommand(
            Guid fornecedorId,
            int categoriaId,
            string? descricao,
            decimal precoCompra,
            decimal precoVenda,
            decimal margemLucro,
            int estoque)
        {
            FornecedorId = fornecedorId;
            CategoriaId = categoriaId;
            Descricao = descricao;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
            MargemLucro = margemLucro;
            Estoque = estoque;
        }
        public override bool IsValid()
        {
            ValidationResult = new AdicionarProdutoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
