using FluentValidation;

namespace SGL.Produto.Core.Application.Commands.Produto.Validation
{
    public class AdicionarProdutoCommandValidation : AbstractValidator<AdicionarProdutoCommand>
    {
        public AdicionarProdutoCommandValidation()
        {
            RuleFor(c => c.FornecedorId)
                .NotEqual(Guid.Empty)
                .WithMessage("Fornecedor do produto não informado.");

            RuleFor(c => c.CategoriaId)
                .GreaterThan(0)
                .WithMessage("Categoria do produto não informado.");

            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("A descrição do produto não foi informada.");

            RuleFor(c => c.PrecoCompra)
                .GreaterThan(0)
                .WithMessage("Preço de compra do produto precisa ser maior que 0 (zero).");

            RuleFor(c => c.PrecoVenda)
                .GreaterThan(0)
                .WithMessage("Preço de venda do produto precisa ser maior que 0 (zero).");
        }
    }
}
