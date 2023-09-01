using AutoMapper;
using MediatR;
using SGL.ContasPagar.Core.Application.Commands.ContasPagar;
using SGL.ContasPagar.Core.Application.Interfaces.Repositories.Domain;
using SGL.ContasPagar.Core.Application.Models;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.ContasPagar.Core.Application.Handlers
{
    public class ContasPagarCommandHandler :
        IRequestHandler<AdicionarContasPagarCommand, DefaultResult>,
        IRequestHandler<AtualizarContasPagarCommand, DefaultResult>
    {
        private readonly IContasPagarRepository _contasPagarRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public ContasPagarCommandHandler(IContasPagarRepository contasPagarRepository, IMediatorHandler mediatorHandler, IMapper mapper)
        {
            _contasPagarRepository = contasPagarRepository;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<DefaultResult> Handle(AdicionarContasPagarCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var contasPagar = _mapper.Map<Domain.Entities.ContasPagar>(request);
            var entity = _mapper.Map<ContasPagarModel>(await _contasPagarRepository.AdicionarContasPagar(contasPagar));

            var result = await _contasPagarRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result, Message = result ? "OK" : "Error" };
        }

        public async Task<DefaultResult> Handle(AtualizarContasPagarCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var contasPagar = _mapper.Map<Domain.Entities.ContasPagar>(request);
            var entity = _mapper.Map<ContasPagarModel>(await _contasPagarRepository.AtualizarContasPagar(contasPagar));

            var result = await _contasPagarRepository.UnitOfWork.Commit();

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
