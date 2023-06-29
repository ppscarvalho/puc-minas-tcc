using System;

namespace SGL.MessageQueue.Models.Fornecedor
{
    public class ResponseFornecedorOut
    {
        public Guid Id { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string? CNPJ { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? Celular { get; set; }
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
