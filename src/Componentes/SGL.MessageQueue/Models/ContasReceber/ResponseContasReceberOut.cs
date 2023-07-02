using SGL.MessageQueue.Models.Cliente;
using System;

namespace SGL.MessageQueue.Models.ContasReceber
{
    public class ResponseContasReceberOut
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string? Situacao { get; set; }
        public ResponseClienteOut? ResponseClienteOut { get; set; }
    }
}
