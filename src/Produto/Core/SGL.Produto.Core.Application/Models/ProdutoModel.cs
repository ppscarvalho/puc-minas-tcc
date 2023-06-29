namespace SGL.Produto.Core.Application.Models
{
    public class ProdutoModel
    {
        public Guid FornecedorId { get; private set; }
        public int CategoriaId { get; private set; }
        public string? Descricao { get; private set; }
        public decimal PrecoCompra { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal MargemLucro { get; private set; }
        public int Estoque { get; private set; }
        public bool Situacao { get; private set; }

        public ProdutoModel(
            Guid fornecedorId,
            int categoriaId,
            string? descricao,
            decimal precoCompra,
            decimal precoVenda,
            decimal margemLucro,
            int estoque,
            bool situacao)
        {
            FornecedorId = fornecedorId;
            CategoriaId = categoriaId;
            Descricao = descricao;
            PrecoCompra = precoCompra;
            PrecoVenda = precoVenda;
            MargemLucro = margemLucro;
            Estoque = estoque;
            Situacao = situacao;
        }
    }
}
