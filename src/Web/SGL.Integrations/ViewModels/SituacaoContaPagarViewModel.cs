namespace SGL.Integrations.ViewModels
{
    public class ContasPagarSituacaoViewModel
    {
        public string? Situacao { get; set; }
        public string? Descricao { get; set; }

        public IEnumerable<ContasPagarSituacaoViewModel> ObterTodas()
        {
            var list = new List<ContasPagarSituacaoViewModel> {
                new ContasPagarSituacaoViewModel { Situacao = "Pago", Descricao = "Pago" },
                new ContasPagarSituacaoViewModel { Situacao = "A_Pagar", Descricao = "A Pagar" },
                new ContasPagarSituacaoViewModel { Situacao = "Nao_Pago", Descricao = "Não Pago" }, };

            return list;
        }
    }
}
