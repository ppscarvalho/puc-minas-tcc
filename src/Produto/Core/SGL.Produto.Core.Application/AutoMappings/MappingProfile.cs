using AutoMapper;
using SGL.MessageQueue.Models.Category;
using SGL.MessageQueue.Models.Produto;
using SGL.Produto.Core.Application.Commands.Produto;
using SGL.Produto.Core.Application.Models;
using SGL.Produto.Core.Domain.Entities;

namespace SGL.Produto.Core.Application.AutoMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Adicionar Produto Command
            CreateMap<ProdutoModel, AdicionarProdutoCommand>().ReverseMap();
            CreateMap<AdicionarProdutoCommand, Domain.Entities.Produto>().ReverseMap();
            CreateMap<Domain.Entities.Produto, AdicionarProdutoCommand>().ReverseMap();

            //Atualizar Produto Command
            CreateMap<ProdutoModel, AtualizarProdutoCommand>().ReverseMap();
            CreateMap<AtualizarProdutoCommand, Domain.Entities.Produto>().ReverseMap();

            //CreateMap<Domain.Entities.Produto, ProdutoModel>().ReverseMap();
            //CreateMap<Domain.Entities.Produto, ResponseProdutoOut>().ReverseMap();

            CreateMap<Categoria, ResponseCategoriaOut>().ReverseMap();

            CreateMap<Domain.Entities.Produto, ResponseProdutoOut>()
                .ForMember(dest => dest.ResponseCategoriaOut, act => act.MapFrom(src => src.Categoria));
        }
    }
}
