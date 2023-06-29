using FluentValidation;

namespace SGL.Fornecedor.Core.Application.Commands.Fornecedor.Validation
{
    public class AtualizarFornecedorCommandValidation : AbstractValidator<AtualizarFornecedorCommand>
    {
        public AtualizarFornecedorCommandValidation()
        {
            RuleFor(c => c.RazaoSocial)
                .NotEmpty()
                .WithMessage("A Razão Social do fornecedor não foi informada.");

            RuleFor(c => c.NomeFantasia)
                .NotEmpty()
                .WithMessage("O Nome de Fantasia do fornecedor não foi informado.");
        }
    }
}
