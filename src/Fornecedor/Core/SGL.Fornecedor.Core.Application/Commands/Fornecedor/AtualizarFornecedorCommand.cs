using SGL.Fornecedor.Core.Application.Commands.Fornecedor.Validation;
using SGL.Resource.Messagens;

namespace SGL.Fornecedor.Core.Application.Commands.Fornecedor
{
    public class AtualizarFornecedorCommand : CommandHandler
    {
        public Guid Id { get; private set; }
        public string? RazaoSocial { get; private set; }
        public string? NomeFantasia { get; private set; }
        public string? CNPJ { get; private set; }
        public string? InscricaoEstadual { get; private set; }
        public string? Celular { get; private set; }
        public string? EnderecoEmail { get; set; }
        public string? Logradouro { get; private set; }
        public string? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? CEP { get; private set; }
        public string? Estado { get; private set; }

        public AtualizarFornecedorCommand(Guid id,
            string? razaoSocial,
            string? nomeFantasia,
            string? cnpj,
            string? inscricaoEstadual,
            string? celular,
            string? enderecoEmail,
            string? logradouro,
            string? numero,
            string? complemento,
            string? bairro,
            string? cidade,
            string? cep,
            string? estado)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            CNPJ = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            Celular = celular;
            EnderecoEmail = enderecoEmail;
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
            ValidationResult = new AtualizarFornecedorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
