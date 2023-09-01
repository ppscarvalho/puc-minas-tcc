using SGL.MessageQueue.Models.Fornecedor;
using System;

namespace SGL.MessageQueue.Models.ContasPagar
{
    public class ResponseContasPagarOut
    {
        public Guid Id { get; set; }
        public Guid FornecedorId { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string? Situacao { get; set; }
        public ResponseFornecedorOut? ResponseFornecedorOut { get; set; }
    }
}
