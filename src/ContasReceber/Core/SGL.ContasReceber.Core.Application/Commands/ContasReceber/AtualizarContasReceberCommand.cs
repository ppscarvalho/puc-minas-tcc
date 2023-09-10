using SGL.ContasReceber.Core.Application.Commands.ContasReceber.Validation;
using SGL.ContasReceber.Core.Domain.Enuns;
using SGL.Resource.Messagens;

namespace SGL.ContasReceber.Core.Application.Commands.ContasReceber
{
    public class AtualizarContasReceberCommand : CommandHandler
    {
        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }
        public ESituacao Situacao { get; private set; }

        public AtualizarContasReceberCommand() { }

        public AtualizarContasReceberCommand(Guid id, Guid customerId, string? description, DateTime dueDate, decimal value)
        {
            Id = id;
            ClienteId = customerId;
            Descricao = description;
            DataVencimento = dueDate;
            Valor = value;
            Situacao = ESituacao.A_Receber;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarContasReceberCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
