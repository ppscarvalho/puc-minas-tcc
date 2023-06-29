using SGL.Cliente.Core.Domain.Validations;
using SGL.Resource.Domain;
using SGL.Resource.Domain.ValueObjects;
using SGL.Resource.Interfaces;

namespace SGL.Cliente.Core.Domain.Entities
{
    public sealed class Cliente : Entity, IAggregateRoot
    {
        public string? Nome { get; private set; }
        public string? CPF { get; private set; }
        public string? Celular { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente() { }

        public Cliente(
            string? nome,
            string? cpf,
            string? celular,
            DateTime? dataNascimento,
            Email email,
            Endereco endereco)
        {
            Nome = nome;
            CPF = cpf;
            Celular = celular;
            DataNascimento = dataNascimento;
            Email = email;
            Endereco = endereco;
        }

        public override bool IsValid()
        {
            ValidationResult = new ClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
