using FluentValidation;

namespace SGL.Cliente.Core.Domain.Validations
{
    public class ClienteValidation : AbstractValidator<Entities.Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O id do cliente não foi informado.");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Primeiro nome do cliente não foi informada.");

            RuleFor(c => c.CPF)
                .NotEmpty()
                .WithMessage("CPF do cliente não foi informado.");
        }
    }
}
