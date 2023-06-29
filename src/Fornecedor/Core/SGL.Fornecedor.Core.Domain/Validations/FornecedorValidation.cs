using FluentValidation;

namespace SGL.Fornecedor.Core.Domain.Validations
{
    public class FornecedorValidation : AbstractValidator<Entities.Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O id do fornecedor não foi informado.");

            RuleFor(c => c.RazaoSocial)
                .NotEmpty()
                .WithMessage("A Razão Social do fornecedor não foi informada.");

            RuleFor(c => c.NomeFantasia)
                .NotEmpty()
                .WithMessage("O Nome de Fantasia do fornecedor não foi informado.");
        }
    }
}
