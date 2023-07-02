using SGL.MessageQueue.Models.Cliente;
using System.ComponentModel.DataAnnotations;

namespace SGL.Integrations.ViewModels
{
    public class ContasReceberViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Cliente obrigatório.")]
        public Guid ClienteId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição da conta obrigatória.")]
        public string? Descricao { get; set; }

        [Display(Name = "Data de Vencimento")]
        [Required(ErrorMessage = "Data de vencimento é obrigatória.")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor é obrigatório.")]
        public decimal Valor { get; set; }

        public string? Status { get; set; }

        public ICollection<ClienteViewModel>? ClienteViewModels { get; set; }
        public ClienteViewModel? ClienteViewModel { get; set; }
        public ResponseClienteOut? ResponseClienteOut { get; set; }

        public string Situacao
        {
            get { return ObterSituacao(); }
        }

        public string ObterSituacao()
        {
            switch (Status)
            {
                case "Pago":
                    return "Pago";

                case "A_Receber":
                    return "A receber";

                case "Nao_Pago":
                    return "Não Pago";

                default:
                    return "Não Pago";
            }
        }
    }
}
