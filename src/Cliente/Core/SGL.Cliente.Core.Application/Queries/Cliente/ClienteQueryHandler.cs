using AutoMapper;
using MediatR;
using SGL.Cliente.Core.Application.Interfaces.Repositories.Domain;
using SGL.Cliente.Core.Application.Models;

namespace SGL.Cliente.Core.Application.Queries.Cliente
{
    public class ClienteQueryHandler :
        IRequestHandler<ObterClientePorIdQuery, ClienteModel>,
        IRequestHandler<ObterTodosClientesQuery, IEnumerable<ClienteModel>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteModel> Handle(ObterClientePorIdQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClienteModel>(await _clienteRepository.ObterClientePorId(query.Id));
        }

        public async Task<IEnumerable<ClienteModel>> Handle(ObterTodosClientesQuery query, CancellationToken cancellationToken)
        {
            var lista = await _clienteRepository.ObterTodosClientes();
            return _mapper.Map<IEnumerable<ClienteModel>>(await _clienteRepository.ObterTodosClientes());
        }
    }
}
