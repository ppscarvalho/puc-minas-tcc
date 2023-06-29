using AutoMapper;
using MediatR;
using SGL.MessageQueue.Models.Produto;
using SGL.Produto.Core.Application.Interfaces.Repositories.Domain;

namespace SGL.Produto.Core.Application.Queries.Produto
{
    public class ProdutoQueryHandler :
        IRequestHandler<ObterProdutoPorIdQuery, ResponseProdutoOut>,
        IRequestHandler<ObterTodosProdutosQuery, IEnumerable<ResponseProdutoOut>>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutoQueryHandler(IProdutoRepository fornecedorRepository, IMapper mapper)
        {
            _produtoRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<ResponseProdutoOut> Handle(ObterProdutoPorIdQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<ResponseProdutoOut>(await _produtoRepository.ObterProdutoPorId(query.Id));
        }

        public async Task<IEnumerable<ResponseProdutoOut>> Handle(ObterTodosProdutosQuery query, CancellationToken cancellationToken)
        {
            var produtos = await _produtoRepository.ObterTodosProdutos();
            return _mapper.Map<IEnumerable<ResponseProdutoOut>>(produtos);
        }
    }
}
