using AutoMapper;
using SGL.ContasPagar.Core.Application.Commands.ContasPagar;
using SGL.ContasPagar.Core.Application.Models;
using SGL.MessageQueue.Models.ContasPagar;

namespace SGL.ContasPagar.Core.Application.AutoMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Adicionar Contas a Pagar Command
            CreateMap<ContasPagarModel, AdicionarContasPagarCommand>().ReverseMap();
            CreateMap<AdicionarContasPagarCommand, Domain.Entities.ContasPagar>().ReverseMap();

            // Atualizar Contas a Pagar Command
            CreateMap<ContasPagarModel, AtualizarContasPagarCommand>().ReverseMap();
            CreateMap<AtualizarContasPagarCommand, Domain.Entities.ContasPagar>().ReverseMap();

            CreateMap<Domain.Entities.ContasPagar, ContasPagarModel>().ReverseMap();
            CreateMap<ContasPagarModel, Domain.Entities.ContasPagar>().ReverseMap();

            CreateMap<Domain.Entities.ContasPagar, ResponseContasPagarOut>();
        }
    }
}
