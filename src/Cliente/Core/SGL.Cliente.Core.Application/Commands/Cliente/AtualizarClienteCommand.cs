using SGL.Cliente.Core.Application.Commands.Cliente.Validation;
using SGL.Resource.Messagens;

namespace SGL.Cliente.Core.Application.Commands.Cliente
{
    public class AtualizarClienteCommand : CommandHandler
    {
        public Guid Id { get; set; }
        public string? Nome { get; private set; }
        public string? CPF { get; private set; }
        public string? Celular { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string? NomeEmail { get; private set; }
        public string? Logradouro { get; private set; }
        public string? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? CEP { get; private set; }
        public string? Estado { get; private set; }

        public AtualizarClienteCommand(
          Guid id,
          string? nome,
          string? cpf,
          string? celular,
          DateTime? dataNascimento,
          string? nomeEmail,
          string? logradouro,
          string? numero,
          string? complemento,
          string? bairro,
          string? cidade,
          string? cep,
          string? estado)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Celular = celular;
            DataNascimento = dataNascimento;
            NomeEmail = nomeEmail;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            CEP = cep;
            Estado = estado;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
