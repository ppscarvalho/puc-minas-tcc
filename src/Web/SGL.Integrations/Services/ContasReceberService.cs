using AutoMapper;
using SGL.Integrations.Htpp.ContasReceber;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

namespace SGL.Integrations.Services
{
    public class ContasReceberService : IContasReceberService
    {
        private readonly IMapper _mapper;
        private readonly IContasReceberClient _contasReceberClient;
        public ContasReceberService(IMapper mapper, IContasReceberClient contasReceberClient)
        {
            _mapper = mapper;
            _contasReceberClient = contasReceberClient;
        }

        public async Task<ContasReceberViewModel> ObterContasReceberPorId(Guid id, string token)
        {
            return await _contasReceberClient.ObterContasReceberPorId(id, token);
        }

        public async Task<IEnumerable<ContasReceberViewModel>> ObterTodosContasRecebers(string token)
        {
            return await _contasReceberClient.ObterTodasContasReceber(token);
        }

        public IEnumerable<ContasReceberSituacaoViewModel> TodosStatus()
        {
            var states = new ContasReceberSituacaoViewModel();
            return states.ObterTodas();
        }

        public async Task<DefaultResult> Adicionar(ContasReceberViewModel contasReceberViewModel, string token)
        {
            return await _contasReceberClient.Adicionar(contasReceberViewModel, token);
        }

        public async Task<DefaultResult> Atualizar(ContasReceberViewModel contasReceberViewModel, string token)
        {
            return await _contasReceberClient.Atualizar(contasReceberViewModel, token);
        }
    }
}
