using AutoMapper;
using SGL.Integrations.Htpp.Fornecedor;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;

namespace SGL.Integrations.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorClient _fornecedorClient;
        public FornecedorService(IMapper mapper, IFornecedorClient fornecedorClient)
        {
            _mapper = mapper;
            _fornecedorClient = fornecedorClient;
        }

        public async Task<FornecedorViewModel> ObterFornecedorPorId(Guid id)
        {
            return await _fornecedorClient.ObterFornecedorPorId(id);
        }

        public async Task<IEnumerable<FornecedorViewModel>> ObterTodosFornecedores()
        {
            return await _fornecedorClient.ObterTodosFornecedores();
        }

        public IEnumerable<EstadoViewModel> TodosEstados()
        {
            var states = new EstadoViewModel();
            return states.TodosEstados();
        }
    }
}
