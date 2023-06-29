using AutoMapper;
using MediatR;
using SGL.Fornecedor.Core.Application.Commands.Fornecedor;
using SGL.Fornecedor.Core.Application.Interfaces.Repositories.Domain;
using SGL.Fornecedor.Core.Application.Models;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.Fornecedor.Core.Application.Handlers
{
    public class FornecedorCommandHandler :
    IRequestHandler<AdicionarFornecedorCommand, DefaultResult>,
        IRequestHandler<AtualizarFornecedorCommand, DefaultResult>
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public FornecedorCommandHandler(
            IFornecedorRepository fornecedorRepository,
            IMediatorHandler mediatorHandler,
            IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<DefaultResult> Handle(AdicionarFornecedorCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var fornecedor = _mapper.Map<Domain.Entities.Fornecedor>(request);
            var entity = _mapper.Map<FornecedorModel>(await _fornecedorRepository.AdicionarFornecedor(fornecedor));

            var result = await _fornecedorRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result };
        }

        public async Task<DefaultResult> Handle(AtualizarFornecedorCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var fornecedor = _mapper.Map<Domain.Entities.Fornecedor>(request);
            var entity = _mapper.Map<FornecedorModel>(await _fornecedorRepository.AtualizarFornecedor(fornecedor));

            var result = await _fornecedorRepository.UnitOfWork.Commit();

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
