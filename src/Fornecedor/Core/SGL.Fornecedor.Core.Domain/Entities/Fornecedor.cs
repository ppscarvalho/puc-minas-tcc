using SGL.Fornecedor.Core.Domain.Validations;
using SGL.Resource.Domain;
using SGL.Resource.Domain.ValueObjects;
using SGL.Resource.Interfaces;

namespace SGL.Fornecedor.Core.Domain.Entities
{
    public sealed class Fornecedor : Entity, IAggregateRoot
    {
        public string? RazaoSocial { get; private set; }
        public string? NomeFantasia { get; private set; }
        public string? CNPJ { get; private set; }
        public string? InscricaoEstadual { get; private set; }
        public string? Celular { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }

        public Fornecedor() { }

        public Fornecedor(
            string? razaoSocial,
            string? nomeFantasia,
            string? cnpj,
            string? inscricaoEstadual,
            string? celular,
            Email email,
            Endereco endereco) : this()
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            CNPJ = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            Celular = celular;
            Email = email;
            Endereco = endereco;

            IsValid();
        }

        public override bool IsValid()
        {
            ValidationResult = new FornecedorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
