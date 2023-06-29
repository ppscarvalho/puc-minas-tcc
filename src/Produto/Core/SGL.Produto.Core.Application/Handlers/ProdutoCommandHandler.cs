using AutoMapper;
using MediatR;
using SGL.Produto.Core.Application.Commands.Produto;
using SGL.Produto.Core.Application.Interfaces.Repositories.Domain;
using SGL.Produto.Core.Application.Models;
using SGL.Resource.Communication.Mediator;
using SGL.Resource.Messagens;
using SGL.Resource.Messagens.CommonMessage.Notifications;
using SGL.Resource.Util;

namespace SGL.Produto.Core.Application.Handlers
{
    public class ProdutoCommandHandler :
    IRequestHandler<AdicionarProdutoCommand, DefaultResult>,
        IRequestHandler<AtualizarProdutoCommand, DefaultResult>
    {
        private readonly IProdutoRepository _ProdutoRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public ProdutoCommandHandler(
            IProdutoRepository ProdutoRepository,
            IMediatorHandler mediatorHandler,
            IMapper mapper)
        {
            _ProdutoRepository = ProdutoRepository;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<DefaultResult> Handle(AdicionarProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var Produto = _mapper.Map<Domain.Entities.Produto>(request);
            var entity = _mapper.Map<ProdutoModel>(await _ProdutoRepository.AdicionarProduto(Produto));

            var result = await _ProdutoRepository.UnitOfWork.Commit();

            return new DefaultResult { Result = entity, Success = result };
        }

        public async Task<DefaultResult> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request)) return new DefaultResult { Result = "Error", Success = false };

            var Produto = _mapper.Map<Domain.Entities.Produto>(request);
            var entity = _mapper.Map<ProdutoModel>(await _ProdutoRepository.AtualizarProduto(Produto));

            var result = await _ProdutoRepository.UnitOfWork.Commit();

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
