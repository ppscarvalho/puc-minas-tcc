using SGL.MessageQueue.Models.Fornecedor;
using System.ComponentModel.DataAnnotations;

namespace SGL.Integrations.ViewModels
{
    public class ContasPagarViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "Fornecedor obrigatório.")]
        public Guid FornecedorId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição da conta obrigatória.")]
        public string? Descricao { get; set; }

        [Display(Name = "Data de Vencimento")]
        [Required(ErrorMessage = "Data de vencimento é obrigatória.")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor é obrigatório.")]
        public decimal Valor { get; set; }

        public string? Situacao { get; set; }

        public ICollection<FornecedorViewModel>? FornecedorViewModels { get; set; }
        public FornecedorViewModel? FornecedorViewModel { get; set; }
        public ResponseFornecedorOut? ResponseFornecedorOut { get; set; }

        public IEnumerable<ContasReceberSituacaoViewModel?>? StatusVieModels { get; set; }

        public string ObterSituacao
        {
            get { return ObterStatus(); }
        }

        public string ObterStatus()
        {
            switch (Situacao)
            {
                case "Pago":
                    return "Pago";

                case "A_Pagar":
                    return "A pagar";

                case "Nao_Pago":
                    return "Não Pago";

                default:
                    return "Não Pago";
            }
        }
    }
}
