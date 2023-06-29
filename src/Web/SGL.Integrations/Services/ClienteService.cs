using AutoMapper;
using SGL.Integrations.Htpp.Cliente;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

namespace SGL.Integrations.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteClient _ClienteClient;
        public ClienteService(IMapper mapper, IClienteClient ClienteClient)
        {
            _mapper = mapper;
            _ClienteClient = ClienteClient;
        }

        public async Task<ClienteViewModel> ObterClientePorId(Guid id)
        {
            return await _ClienteClient.ObterClientePorId(id);
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterTodosClientes()
        {
            return await _ClienteClient.ObterTodosClientes();
        }

        public IEnumerable<EstadoViewModel> TodosEstados()
        {
            var states = new EstadoViewModel();
            return states.TodosEstados();
        }
    }
}
