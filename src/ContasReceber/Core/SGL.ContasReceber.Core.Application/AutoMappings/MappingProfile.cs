using AutoMapper;
using SGL.ContasReceber.Core.Application.Commands.ContasReceber;
using SGL.ContasReceber.Core.Application.Models;
using SGL.MessageQueue.Models.ContasReceber;

namespace SGL.ContasReceber.Core.Application.AutoMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Adicionar Contas a Receber Command
            CreateMap<ContasReceberModel, AdicionarContasReceberCommand>().ReverseMap();
            CreateMap<AdicionarContasReceberCommand, Domain.Entities.ContasReceber>().ReverseMap();

            // Atualizar Contas a Receber Command
            CreateMap<ContasReceberModel, AtualizarContasReceberCommand>().ReverseMap();
            CreateMap<AtualizarContasReceberCommand, Domain.Entities.ContasReceber>().ReverseMap();

            CreateMap<Domain.Entities.ContasReceber, ContasReceberModel>().ReverseMap();
            CreateMap<ContasReceberModel, Domain.Entities.ContasReceber>().ReverseMap();

            CreateMap<Domain.Entities.ContasReceber, ResponseContasReceberOut>();
        }
    }
}
