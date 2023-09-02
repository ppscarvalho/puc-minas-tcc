using System.ComponentModel.DataAnnotations;

namespace SGL.Integrations.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Categoria")]
        public string? Descricao { get; set; }

        public IEnumerable<CategoriaViewModel> TodasCategorias()
        {
            var list = new List<CategoriaViewModel> {
                new CategoriaViewModel { Id = 1, Descricao = "Bijouteria" },
                new CategoriaViewModel { Id = 3, Descricao = "Cosméticos" },
                new CategoriaViewModel { Id = 5, Descricao = "Roupas Infantis" },
                new CategoriaViewModel { Id = 6, Descricao = "Roupas Masculinas" }            };

            return list;
        }
    }
}
