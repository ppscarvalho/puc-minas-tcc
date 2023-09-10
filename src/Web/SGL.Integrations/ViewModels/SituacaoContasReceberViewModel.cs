namespace SGL.Integrations.ViewModels
{
    public class ContasReceberSituacaoViewModel
    {
        public string? Situacao { get; set; }
        public string? Descricao { get; set; }

        public IEnumerable<ContasReceberSituacaoViewModel> ObterTodas()
        {
            var list = new List<ContasReceberSituacaoViewModel> {
                new ContasReceberSituacaoViewModel { Situacao = "Pago", Descricao = "Pago" },
                new ContasReceberSituacaoViewModel { Situacao = "A_Receber", Descricao = "A Receber" },
                new ContasReceberSituacaoViewModel { Situacao = "Não_Pago", Descricao = "Não Pago" }, };

            return list;
        }
    }
}
