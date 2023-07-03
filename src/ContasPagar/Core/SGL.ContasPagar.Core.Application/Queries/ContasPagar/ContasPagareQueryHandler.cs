using AutoMapper;
using MediatR;
using SGL.ContasPagar.Core.Application.Interfaces.Repositories.Domain;
using SGL.MessageQueue.Models.ContasPagar;

namespace SGL.ContasPagar.Core.Application.Queries.ContasPagar
{
    public class ContasPagareQueryHandler :
            IRequestHandler<ObterContasPagarPorIdQuery, ResponseContasPagarOut>,
            IRequestHandler<ObterTodasContasPagarQuery, IEnumerable<ResponseContasPagarOut>>
    {
        private readonly IContasPagarRepository _contasPagarRepository;
        private readonly IMapper _mapper;
        public ContasPagareQueryHandler(IContasPagarRepository contasPagarRepository, IMapper mapper)
        {
            _contasPagarRepository = contasPagarRepository;
            _mapper = mapper;
        }

        public async Task<ResponseContasPagarOut> Handle(ObterContasPagarPorIdQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<ResponseContasPagarOut>(await _contasPagarRepository.ObterContasPagarPorId(query.Id));
        }

        public async Task<IEnumerable<ResponseContasPagarOut>> Handle(ObterTodasContasPagarQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ResponseContasPagarOut>>(await _contasPagarRepository.ObterTodasContasPagar());
        }
    }
}
