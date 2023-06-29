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
