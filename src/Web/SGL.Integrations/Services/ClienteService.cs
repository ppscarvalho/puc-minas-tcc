using AutoMapper;
using SGL.Integrations.Htpp.Cliente;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

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

        public async Task<ClienteViewModel> ObterClientePorId(Guid id, string token)
        {
            return await _ClienteClient.ObterClientePorId(id, token);
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterTodosClientes(string token)
        {
            return await _ClienteClient.ObterTodosClientes(token);
        }

        public IEnumerable<EstadoViewModel> TodosEstados()
        {
            var states = new EstadoViewModel();
            return states.TodosEstados();
        }

        public async Task<DefaultResult> Adicionar(ClienteViewModel clienteViewModel, string token)
        {
            return await _ClienteClient.Adicionar(clienteViewModel, token);
        }

        public async Task<DefaultResult> Atualizar(ClienteViewModel clienteViewModel, string token)
        {
            return await _ClienteClient.Atualizar(clienteViewModel, token);
        }
    }
}
