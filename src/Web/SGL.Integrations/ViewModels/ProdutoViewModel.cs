using SGL.MessageQueue.Models.Category;
using SGL.MessageQueue.Models.Fornecedor;
using System.ComponentModel.DataAnnotations;

namespace SGL.Integrations.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid? Id { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Fornecedor do Produto obrigatório.")]
        public Guid FornecedorId { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria do Produto obrigatório.")]
        public int CategoriaId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição do Produto obrigatória.")]
        public string? Descricao { get; set; }

        [Display(Name = "Preço de Compra")]
        [Required(ErrorMessage = "Preço de Compra do Produto obrigatório.")]
        public decimal PrecoCompra { get; set; }

        [Display(Name = "Preço de Venda")]
        [Required(ErrorMessage = "Preço de Venda do Produto obrigatório.")]
        public decimal PrecoVenda { get; set; }

        [Display(Name = "Margem de Lucro")]
        [Required(ErrorMessage = "Margem de Lucro do Produto obrigatório.")]
        public decimal MargemLucro { get; set; }

        [Display(Name = "Estoque")]
        [Required(ErrorMessage = "Estoque do Produto obrigatório.")]
        public int Estoque { get; set; }

        [Display(Name = "Lucro Obtido")]
        public decimal LucroObtido { get; set; }

        public ICollection<FornecedorViewModel>? FornecedorViewModels { get; set; }
        public ICollection<CategoriaViewModel>? CategoriaViewModels { get; set; }

        public ResponseCategoriaOut? ResponseCategoriaOut { get; set; }
        public ResponseFornecedorOut? ResponseFornecedorOut { get; set; }
    }
}
