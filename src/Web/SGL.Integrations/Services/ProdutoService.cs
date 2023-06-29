using AutoMapper;
using SGL.Integrations.Htpp.Produto;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

namespace SGL.Integrations.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoClient _produtoClient;
        public ProdutoService(IMapper mapper, IProdutoClient produtoClient)
        {
            _mapper = mapper;
            _produtoClient = produtoClient;
        }

        public async Task<ProdutoViewModel> ObterProdutoPorId(Guid id)
        {
            return await _produtoClient.ObterProdutoPorId(id);
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodosProdutos()
        {
            return await _produtoClient.ObterTodosProdutos();
        }
    }
}
