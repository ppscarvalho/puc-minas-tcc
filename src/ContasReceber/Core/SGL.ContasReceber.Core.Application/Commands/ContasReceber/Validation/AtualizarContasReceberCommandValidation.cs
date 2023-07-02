﻿using FluentValidation;

namespace SGL.ContasReceber.Core.Application.Commands.ContasReceber.Validation
{
    public class AtualizarContasReceberCommandValidation : AbstractValidator<AtualizarContasReceberCommand>
    {
        public AtualizarContasReceberCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O id da conta não foi informado.");

            RuleFor(c => c.ClienteId)
                .NotEmpty()
                .WithMessage("O id do cliente não foi informado.");

            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("A descrição da conta não foi informada.");

            RuleFor(c => c.DataVencimento)
                .NotEmpty()
                .WithMessage("A data de vencimento da conta não foi informada.");

            RuleFor(c => c.Valor)
                .NotEmpty()
                .WithMessage("o valor da conta não foi informado.");
        }
    }
}

