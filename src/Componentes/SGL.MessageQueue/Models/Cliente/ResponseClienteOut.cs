using System;

namespace SGL.MessageQueue.Models.Cliente
{
    public class ResponseClienteOut
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Celular { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? EnderecoEmail { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? CEP { get; set; }
        public string? Estado { get; set; }
    }
}
