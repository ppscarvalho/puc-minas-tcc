using FluentValidation;

namespace SGL.Cliente.Core.Application.Commands.Cliente.Validation
{
    public class AdicionarClienteCommandValidation : AbstractValidator<AdicionarClienteCommand>
    {
        public AdicionarClienteCommandValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Primeiro nome do cliente não foi informada.");

            RuleFor(c => c.CPF)
                .NotEmpty()
                .WithMessage("CPF do cliente não foi informado.");
        }
    }
}
