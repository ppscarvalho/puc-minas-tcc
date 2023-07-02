namespace SGL.ContasReceber.Core.Application.Models
{
    public class ContasReceberModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string? Situacao { get; set; }
    }
}
