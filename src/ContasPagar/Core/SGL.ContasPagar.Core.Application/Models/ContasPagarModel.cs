namespace SGL.ContasPagar.Core.Application.Models
{
    public class ContasPagarModel
    {
        public Guid Id { get; set; }
        public Guid FornecedorId { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string? Situacao { get; set; }
    }
}
