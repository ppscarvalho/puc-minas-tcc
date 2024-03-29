﻿using SGL.ContasPagar.Core.Application.Commands.ContasPagar.Validation;
using SGL.ContasPagar.Core.Domain.Enuns;
using SGL.Resource.Messagens;

namespace SGL.ContasPagar.Core.Application.Commands.ContasPagar
{
    public class AdicionarContasPagarCommand : CommandHandler
    {
        public Guid FornecedorId { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }
        public ESituacao Situacao { get; private set; }

        public AdicionarContasPagarCommand() { }

        public AdicionarContasPagarCommand(Guid fornecedorId, string? descricao, DateTime dataVencimento, decimal valor)
        {
            FornecedorId = fornecedorId;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Valor = valor;
            Situacao = ESituacao.A_Pagar;
        }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarContasPagarCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
