using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SGL.Integrations.ViewModels;
using SGL.MessageQueue.Models.Cliente;
using SGL.MessageQueue.Models.Fornecedor;

namespace SGL.Integrations.AutoMapper
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()), typeof(object));
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cliente
            CreateMap<ClienteViewModel, ResponseClienteOut>().ReverseMap();

            // Fornecedor
            CreateMap<FornecedorViewModel, ResponseFornecedorOut>().ReverseMap();

            // Category
            //CreateMap<CategoryViewModel, ResponseCategoryOut>().ReverseMap();

            // Product
            //CreateMap<ProductViewModel, ResponseProductOut>().ReverseMap();


            // BillToPay
            //CreateMap<BillToPayViewModel, ResponseBillToPayOut>().ReverseMap();

            // AccountReceivable
            //CreateMap<AccountReceivableViewModel, ResponseAccountReceivableOut>().ReverseMap();
        }
    }
}
