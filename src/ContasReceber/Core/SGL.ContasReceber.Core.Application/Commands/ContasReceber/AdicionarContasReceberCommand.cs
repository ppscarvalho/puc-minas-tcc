using SGL.ContasReceber.Core.Application.Commands.ContasReceber.Validation;
using SGL.ContasReceber.Core.Domain.Enuns;
using SGL.Resource.Messagens;

namespace SGL.ContasReceber.Core.Application.Commands.ContasReceber
{
    public class AdicionarContasReceberCommand : CommandHandler
    {
        public Guid ClienteId { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }
        public ESituacao Situacao { get; private set; }

        public AdicionarContasReceberCommand() { }

        public AdicionarContasReceberCommand(Guid clienteId, string? descricao, DateTime dataVencimento, decimal valor) : this()
        {
            ClienteId = clienteId;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Valor = valor;
            Situacao = ESituacao.A_Receber;
        }

        public override bool IsValid()
        {
            ValidationResult = new AdicionarContasReceberCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
