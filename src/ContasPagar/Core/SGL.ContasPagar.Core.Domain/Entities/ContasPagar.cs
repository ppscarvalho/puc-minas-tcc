using SGL.ContasPagar.Core.Domain.Enuns;
using SGL.ContasPagar.Core.Domain.Validations;
using SGL.Resource.Domain;
using SGL.Resource.Interfaces;

namespace SGL.ContasPagar.Core.Domain.Entities
{
    public class ContasPagar : Entity, IAggregateRoot
    {
        public Guid FornecedorId { get; private set; }
        public string? Descricao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Valor { get; private set; }
        public ESituacao Situacao { get; private set; }

        public ContasPagar() { }

        public ContasPagar(Guid fornecedorId, string? descricao, DateTime dataVencimento, decimal valor)
        {
            FornecedorId = fornecedorId;
            Descricao = descricao;
            DataVencimento = dataVencimento;
            Valor = valor;
            Situacao = ESituacao.Nao_Pago;

            IsValid();
        }

        public void AtualizarSituacaoParaPago()
        {
            Situacao = ESituacao.Pago;
        }

        public override bool IsValid()
        {
            ValidationResult = new ContasPagarValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
