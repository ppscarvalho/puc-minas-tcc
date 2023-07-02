using AutoMapper;
using MediatR;
using SGL.ContasReceber.Core.Application.Commands.ContasReceber;
using SGL.ContasReceber.Core.Application.Interfaces.Repositories.Domain;
using SGL.ContasReceber.Core.Application.Models;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.ContasReceber.Core.Application.Handlers
{
    public class ContasReceberCommandHandler :
        IRequestHandler<AdicionarContasReceberCommand, DefaultResult>,
        IRequestHandler<AtualizarContasReceberCommand, DefaultResult>
    {
        private readonly IContasReceberRepository _contasReceberRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public ContasReceberCommandHandler(IContasReceberRepository contasReceberRepository, IMediatorHandler mediatorHandler, IMapper mapper)
        {
            _contasReceberRepository = contasReceberRepository;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<DefaultResult> Handle(AdicionarContasReceberCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var biilToPay = _mapper.Map<Domain.Entities.ContasReceber>(request);
            var entity = _mapper.Map<ContasReceberModel>(await _contasReceberRepository.AdicionarContasReceber(biilToPay));

            var result = await _contasReceberRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result, Message = result ? "OK" : "Error" };
        }

        public async Task<DefaultResult> Handle(AtualizarContasReceberCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var biilToPay = _mapper.Map<Domain.Entities.ContasReceber>(request);
            var entity = _mapper.Map<ContasReceberModel>(await _contasReceberRepository.AtualizarContasReceber(biilToPay));

            var result = await _contasReceberRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result, Message = result ? "OK" : "Error" };
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
