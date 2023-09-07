namespace SGL.Integrations.ViewModels
{
    public class StatusViewModel
    {
        public string? Situacao { get; set; }
        public string? Descricao { get; set; }

        public IEnumerable<StatusViewModel> ObterTodosStatus()
        {
            var list = new List<StatusViewModel> {
                new StatusViewModel { Situacao = "Pago", Descricao = "Pago" },
                new StatusViewModel { Situacao = "A_Pagar", Descricao = "A pagar" },
                new StatusViewModel { Situacao = "Nao_Pago", Descricao = "Não Pago" }, };

            return list;
        }
    }
}
