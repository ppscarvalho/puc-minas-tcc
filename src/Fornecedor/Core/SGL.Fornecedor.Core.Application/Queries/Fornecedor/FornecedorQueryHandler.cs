using AutoMapper;
using MediatR;
using SGL.Fornecedor.Core.Application.Interfaces.Repositories.Domain;
using SGL.Fornecedor.Core.Application.Models;

namespace SGL.Fornecedor.Core.Application.Queries.Fornecedor
{
    public class FornecedorQueryHandler :
        IRequestHandler<ObterFornecedorPorIdQuery, FornecedorModel>,
        IRequestHandler<ObterTodosFornecedoresQuery, IEnumerable<FornecedorModel>>
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;
        public FornecedorQueryHandler(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<FornecedorModel> Handle(ObterFornecedorPorIdQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<FornecedorModel>(await _fornecedorRepository.ObterFornecedorPorId(query.Id));
        }

        public async Task<IEnumerable<FornecedorModel>> Handle(ObterTodosFornecedoresQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<FornecedorModel>>(await _fornecedorRepository.ObterTodosFornecedores());
        }
    }
}
