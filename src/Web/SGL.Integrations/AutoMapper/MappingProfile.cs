using AutoMapper;
using SGL.Integrations.ViewModels;
using SGL.MessageQueue.Models.Category;
using SGL.MessageQueue.Models.Cliente;
using SGL.MessageQueue.Models.ContasReceber;
using SGL.MessageQueue.Models.Fornecedor;
using SGL.MessageQueue.Models.Produto;

namespace SGL.Integrations.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cliente
            CreateMap<ClienteViewModel, ResponseClienteOut>().ReverseMap();

            // Fornecedor
            CreateMap<FornecedorViewModel, ResponseFornecedorOut>().ReverseMap();

            // Categoria
            CreateMap<CategoriaViewModel, ResponseCategoriaOut>().ReverseMap();

            // Product
            CreateMap<ProdutoViewModel, ResponseProdutoOut>().ReverseMap();


            // BillToPay
            //CreateMap<BillToPayViewModel, ResponseBillToPayOut>().ReverseMap();

            // Contas a Receber
            CreateMap<ContasReceberViewModel, ResponseContasReceberOut>().ReverseMap();
        }
    }
}
