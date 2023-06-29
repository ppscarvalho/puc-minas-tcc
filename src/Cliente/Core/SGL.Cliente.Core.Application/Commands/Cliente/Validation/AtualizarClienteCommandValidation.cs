using FluentValidation;

namespace SGL.Cliente.Core.Application.Commands.Cliente.Validation
{
    public class AtualizarClienteCommandValidation : AbstractValidator<AtualizarClienteCommand>
    {
        public AtualizarClienteCommandValidation()
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
