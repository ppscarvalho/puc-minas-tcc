using SGL.ContasReceber.Core.Domain.Enuns;
using SGL.ContasReceber.Core.Domain.Validations;
using SGL.Resource.Domain;
using SGL.Resource.Interfaces;

namespace SGL.ContasReceber.Core.Domain.Entities
{
    public sealed class ContasReceber : Entity, IAggregateRoot
    {
        public Guid ClienteId { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }
        public ESituacao Situacao { get; private set; }

        public ContasReceber() { }

        public ContasReceber(Guid clienteId, string? descricao, DateTime dataVencimento, decimal valor) : this()
        {
            ClienteId = clienteId;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Valor = valor;
            Situacao = ESituacao.A_Receber;

            IsValid();
        }

        public void AlterarSituacaoParaPago()
        {
            Situacao = ESituacao.Pago;
        }

        public override bool IsValid()
        {
            ValidationResult = new ContasReceberValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
