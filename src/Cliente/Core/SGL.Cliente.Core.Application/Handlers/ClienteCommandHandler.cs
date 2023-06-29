using AutoMapper;
using MediatR;
using SGL.Cliente.Core.Application.Commands.Cliente;
using SGL.Cliente.Core.Application.Interfaces.Repositories.Domain;
using SGL.Cliente.Core.Application.Models;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.Cliente.Core.Application.Handlers
{
    public class ClienteCommandHandler :
       IRequestHandler<AdicionarClienteCommand, DefaultResult>,
           IRequestHandler<AtualizarClienteCommand, DefaultResult>
    {
        private readonly IClienteRepository _CustomerRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public ClienteCommandHandler(
            IClienteRepository CustomerRepository,
            IMediatorHandler mediatorHandler,
            IMapper mapper)
        {
            _CustomerRepository = CustomerRepository;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<DefaultResult> Handle(AdicionarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var cliente = _mapper.Map<Domain.Entities.Cliente>(request);
            var entity = _mapper.Map<ClienteModel>(await _CustomerRepository.AdicionarCliente(cliente));

            var result = await _CustomerRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result };
        }

        public async Task<DefaultResult> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var cliente = _mapper.Map<Domain.Entities.Cliente>(request);
            var entity = _mapper.Map<ClienteModel>(await _CustomerRepository.AtualizarCliente(cliente));

            var result = await _CustomerRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result };
        }

        private bool ValidateCommand(CommandHandler message)
        {
            if (message.IsValid()) return true;

            foreach (var error in message.ValidationResult.Errors)
                _mediatorHandler.PublishNotification(new DomainNotification(message.MessageType, error.ErrorMessage));

            return false;
        }
    }
}
