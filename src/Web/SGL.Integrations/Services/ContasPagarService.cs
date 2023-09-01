using AutoMapper;
using SGL.Integrations.Htpp.ContasPagar;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

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

        public async Task<ContasPagarViewModel> ObterContasPagarPorId(Guid id)
        {
            return await _contasPagarClient.ObterContasPagarPorId(id);
        }

        public async Task<IEnumerable<ContasPagarViewModel>> ObterTodasContasPagar()
        {
            return await _contasPagarClient.ObterTodasContasPagar();
        }
    }
}
