using AutoMapper;
using MediatR;
using SGL.ContasReceber.Core.Application.Interfaces.Repositories.Domain;
using SGL.MessageQueue.Models.ContasReceber;

namespace SGL.ContasReceber.Core.Application.Queries.ContasReceber
{
    public class ContasRecebereQueryHandler :
             IRequestHandler<ObterContasReceberPorIdQuery, ResponseContasReceberOut>,
             IRequestHandler<ObterTodasContasReceberQuery, IEnumerable<ResponseContasReceberOut>>
    {
        private readonly IContasReceberRepository _contasReceberRepository;
        private readonly IMapper _mapper;
        public ContasRecebereQueryHandler(IContasReceberRepository contasReceberRepository, IMapper mapper)
        {
            _contasReceberRepository = contasReceberRepository;
            _mapper = mapper;
        }

        public async Task<ResponseContasReceberOut> Handle(ObterContasReceberPorIdQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<ResponseContasReceberOut>(await _contasReceberRepository.ObterContasReceberPorId(query.Id));
        }

        public async Task<IEnumerable<ResponseContasReceberOut>> Handle(ObterTodasContasReceberQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ResponseContasReceberOut>>(await _contasReceberRepository.ObterTodasContasReceber());
        }
    }
}
