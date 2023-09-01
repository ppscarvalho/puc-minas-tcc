using System.ComponentModel.DataAnnotations;

namespace SGL.Integrations.ViewModels
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "CPF é obritório.")]
        public string? CPF { get; set; }

        [Required(ErrorMessage = "Celular é obritório.")]
        public string? Celular { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail é obritório.")]
        public string? EnderecoEmail { get; set; }

        [Required(ErrorMessage = "Logradouro é obritório.")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "Bairro é obritório.")]
        public string? Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obritório.")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "CEP é obritório.")]
        public string? CEP { get; set; }

        [Required(ErrorMessage = "UF é obritório.")]
        [Display(Name = "UF")]
        public string? Estado { get; set; }
        public IEnumerable<EstadoViewModel?>? Estados { get; set; }
    }
}
