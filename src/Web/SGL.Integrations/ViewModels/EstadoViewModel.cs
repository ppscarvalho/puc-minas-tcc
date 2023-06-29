namespace SGL.Integrations.ViewModels
{
    public class EstadoViewModel
    {
        public string? UF { get; set; }
        public string? Descricao { get; set; }

        public IEnumerable<EstadoViewModel> TodosEstados()
        {
            var list = new List<EstadoViewModel> {
                new EstadoViewModel { UF = "AC", Descricao = "Acre" },
                new EstadoViewModel { UF = "AL", Descricao = "Alagoas" },
                new EstadoViewModel { UF = "AP", Descricao = "Amapá" },
                new EstadoViewModel { UF = "AM", Descricao = "Amazonas" },
                new EstadoViewModel { UF = "BA", Descricao = "Bahia" },
                new EstadoViewModel { UF = "CE", Descricao = "Ceará" },
                new EstadoViewModel { UF = "ES", Descricao = "Espírito Santo" },
                new EstadoViewModel { UF = "GO", Descricao = "Goiás" },
                new EstadoViewModel { UF = "MA", Descricao = "Maranhão" },
                new EstadoViewModel { UF = "MT", Descricao = "Mato Grosso" },
                new EstadoViewModel { UF = "MS", Descricao = "Mato Grosso do Sul" },
                new EstadoViewModel { UF = "MG", Descricao = "Minas Gerais" },
                new EstadoViewModel { UF = "PA", Descricao = "Pará" },
                new EstadoViewModel { UF = "PB", Descricao = "Paraíba" },
                new EstadoViewModel { UF = "PR", Descricao = "Paraná" },
                new EstadoViewModel { UF = "PE", Descricao = "Pernambuco" },
                new EstadoViewModel { UF = "PI", Descricao = "Piauí" },
                new EstadoViewModel { UF = "RJ", Descricao = "Rio de Janeiro" },
                new EstadoViewModel { UF = "RN", Descricao = "Rio Grande do Norte" },
                new EstadoViewModel { UF = "RS", Descricao = "Rio Grande do Sul" },
                new EstadoViewModel { UF = "RO", Descricao = "Rondônia" },
                new EstadoViewModel { UF = "RR", Descricao = "Roraima" },
                new EstadoViewModel { UF = "SC", Descricao = "Santa Catarina" },
                new EstadoViewModel { UF = "SP", Descricao = "São Paulo" },
                new EstadoViewModel { UF = "SE", Descricao = "Sergipe" },
                new EstadoViewModel { UF = "TO", Descricao = "Tocantins" },
                new EstadoViewModel { UF = "DF", Descricao = "Distrito Federal" },
            };

            return list;
        }
    }
}
