using AutoMapper;
using SGL.Integrations.Htpp.ContasPagar;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

namespace SGL.Integrations.Services
{
    public class ContasPagarService : IContasPagarService
    {
        private readonly IMapper _mapper;
        private readonly IContasPagarClient _contasPagarClient;
        public ContasPagarService(IMapper mapper, IContasPagarClient contasPagarClient)
        {
            _mapper = mapper;
            _contasPagarClient = contasPagarClient;
        }

        public async Task<ContasPagarViewModel> ObterContasPagarPorId(Guid id, string token)
        {
            return await _contasPagarClient.ObterContasPagarPorId(id, token);
        }

        public async Task<IEnumerable<ContasPagarViewModel>> ObterTodosContasPagars(string token)
        {
            return await _contasPagarClient.ObterTodasContasPagar(token);
        }

        public IEnumerable<StatusViewModel> TodosStatus()
        {
            var states = new StatusViewModel();
            return states.ObterTodosStatus();
        }

        public async Task<DefaultResult> Adicionar(ContasPagarViewModel contasPagarViewModel, string token)
        {
            return await _contasPagarClient.Adicionar(contasPagarViewModel, token);
        }

        public async Task<DefaultResult> Atualizar(ContasPagarViewModel contasPagarViewModel, string token)
        {
            return await _contasPagarClient.Atualizar(contasPagarViewModel, token);
        }
    }
}
