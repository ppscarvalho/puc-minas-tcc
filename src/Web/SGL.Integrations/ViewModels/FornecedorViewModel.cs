using System.ComponentModel.DataAnnotations;

namespace SGL.Integrations.ViewModels
{
    public class FornecedorViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Razão Social é obrigatória.")]
        public string? RazaoSocial { get; set; }

        [Display(Name = "Nome de Fantasia")]
        [Required(ErrorMessage = "Nome de Fantasia é obrigatório.")]
        public string? NomeFantasia { get; set; }

        public string? CNPJ { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string? InscricaoEstadual { get; set; }

        public string? Celular { get; set; }

        [Display(Name = "E-mail")]
        public string? EnderecoEmail { get; set; }

        public string? Logradouro { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? CEP { get; set; }

        [Display(Name = "UF")]
        public string? Estado { get; set; }
        public IEnumerable<EstadoViewModel?>? Estados { get; set; }
    }
}
