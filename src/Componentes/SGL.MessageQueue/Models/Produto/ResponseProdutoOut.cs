using SGL.MessageQueue.Models.Category;
using SGL.MessageQueue.Models.Fornecedor;
using System;

namespace SGL.MessageQueue.Models.Produto
{
    public class ResponseProdutoOut
    {
        public Guid Id { get; set; }
        public Guid FornecedorId { get; set; }
        public int CategoriaId { get; set; }
        public string? Descricao { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal MargemLucro { get; set; }
        public int Estoque { get; set; }
        public bool Situacao { get; set; }
        public ResponseFornecedorOut? ResponseFornecedorOut { get; set; }
        public ResponseCategoriaOut? ResponseCategoriaOut { get; set; }
    }
}
