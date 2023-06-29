namespace SGL.Produto.Core.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string? Descricao { get; set; }

        // EF Relation
        public required ICollection<Produto> Produto { get; set; }
    }
}
