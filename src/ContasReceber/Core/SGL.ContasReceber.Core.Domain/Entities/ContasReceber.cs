using SGL.ContasReceber.Core.Domain.Enuns;
using SGL.Resource.Domain;
using SGL.Resource.Interfaces;

namespace SGL.ContasReceber.Core.Domain.Entities
{
    public class ContasReceber : Entity, IAggregateRoot
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
        }

        public void AlterarSituacaoParaPago()
        {
            Situacao = ESituacao.Pago;
        }
    }
}
