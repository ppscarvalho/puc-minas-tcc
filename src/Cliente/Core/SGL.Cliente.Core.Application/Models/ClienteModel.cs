namespace SGL.Cliente.Core.Application.Models
{
    public class ClienteModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; private set; }
        public string? CPF { get; private set; }
        public string? Celular { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string? EnderecoEmail { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? CEP { get; set; }
        public string? Estado { get; set; }

        public ClienteModel(
            Guid id,
            string? nome,
            string? cpf,
            string? celular,
            DateTime? dataNascimento,
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
            Nome = nome;
            CPF = cpf;
            Celular = celular;
            DataNascimento = dataNascimento;
            EnderecoEmail = enderecoEmail;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            CEP = cep;
            Estado = estado;
        }
    }
}
