using System.ComponentModel.DataAnnotations;

namespace SGL.Integrations.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Descrição da Categoria obrigatória.")]
        public string? Descricao { get; set; }
    }
}
