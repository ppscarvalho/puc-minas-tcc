﻿using FluentValidation;

namespace SGL.ContasPagar.Core.Application.Commands.ContasPagar.Validation
{
    public class AtualizarContasPagarCommandValidation : AbstractValidator<AtualizarContasPagarCommand>
    {
        public AtualizarContasPagarCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O id da conta não foi informado.");

            RuleFor(c => c.FornecedorId)
                .NotEmpty()
                .WithMessage("O id do fornecedor não foi informado.");

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
