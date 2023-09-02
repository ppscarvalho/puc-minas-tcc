using AutoMapper;
using SGL.Integrations.Htpp.Produto;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

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

        public async Task<ProdutoViewModel> ObterProdutoPorId(Guid id, string token)
        {
            return await _produtoClient.ObterProdutoPorId(id, token);
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodosProdutos(string token)
        {
            return await _produtoClient.ObterTodosProdutos(token);
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterTodasCategorias()
        {
            await Task.CompletedTask;
            var states = new CategoriaViewModel();
            return states.TodasCategorias();
        }

        public async Task<DefaultResult> Adicionar(ProdutoViewModel produtoViewModel, string token)
        {
            return await _produtoClient.Adicionar(produtoViewModel, token);
        }

        public async Task<DefaultResult> Atualizar(ProdutoViewModel produtoViewModel, string token)
        {
            return await _produtoClient.Atualizar(produtoViewModel, token);
        }
    }
}
