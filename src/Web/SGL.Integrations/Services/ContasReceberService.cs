using AutoMapper;
using SGL.Integrations.Htpp.ContasReceber;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

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

        public async Task<ContasReceberViewModel> ObterContasReceberPorId(Guid id)
        {
            return await _contasReceberClient.ObterContasReceberPorId(id);
        }

        public async Task<IEnumerable<ContasReceberViewModel>> ObterTodasContasReceber()
        {
            return await _contasReceberClient.ObterTodasContasReceber();
        }
    }
}
