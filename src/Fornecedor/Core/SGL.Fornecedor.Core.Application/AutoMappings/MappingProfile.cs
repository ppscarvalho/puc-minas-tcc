using AutoMapper;
using SGL.Fornecedor.Core.Application.Commands.Fornecedor;
using SGL.Fornecedor.Core.Application.Models;
using SGL.MessageQueue.Models.Fornecedor;
using SGL.Resource.Domain.ValueObjects;

namespace SGL.Fornecedor.Core.Application.AutoMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Adicionar Fornecedor Command
            CreateMap<FornecedorModel, AdicionarFornecedorCommand>().ReverseMap();
            CreateMap<AdicionarFornecedorCommand, Domain.Entities.Fornecedor>().ConstructUsing(b => new Domain.Entities.Fornecedor(
                    b.RazaoSocial,
                    b.NomeFantasia,
                    b.CNPJ,
                    b.InscricaoEstadual,
                    b.Celular,
                    new Email(b.EnderecoEmail),
                    new Endereco(b.Logradouro,
                    b.Numero,
                    b.Complemento,
                    b.Bairro,
                    b.Cidade,
                    b.CEP,
                    b.Estado)));

            CreateMap<Domain.Entities.Fornecedor, AdicionarFornecedorCommand>().ConstructUsing(b => new AdicionarFornecedorCommand(
                       b.Id,
                       b.RazaoSocial,
                       b.NomeFantasia,
                       b.CNPJ,
                       b.InscricaoEstadual,
                       b.Celular,
                       b.Email.EnderecoEmail,
                       b.Endereco.Logradouro,
                       b.Endereco.Numero,
                       b.Endereco.Complemento,
                       b.Endereco.Bairro,
                       b.Endereco.Cidade,
                       b.Endereco.CEP,
                       b.Endereco.Estado));

            //Atualizar Fornecedor Command
            CreateMap<FornecedorModel, AtualizarFornecedorCommand>().ReverseMap();
            CreateMap<AtualizarFornecedorCommand, Domain.Entities.Fornecedor>().ConstructUsing(b => new Domain.Entities.Fornecedor(
                    b.RazaoSocial,
                    b.NomeFantasia,
                    b.CNPJ,
                    b.InscricaoEstadual,
                    b.Celular,
                    new Email(b.EnderecoEmail),
                    new Endereco(b.Logradouro,
                    b.Numero,
                    b.Complemento,
                    b.Bairro,
                    b.Cidade,
                    b.CEP,
                    b.Estado)));

            CreateMap<Domain.Entities.Fornecedor, FornecedorModel>().ConstructUsing(b => new FornecedorModel(
                       b.Id,
                       b.RazaoSocial,
                       b.NomeFantasia,
                       b.CNPJ,
                       b.InscricaoEstadual,
                       b.Celular,
                       b.Email.EnderecoEmail,
                       b.Endereco.Logradouro,
                       b.Endereco.Numero,
                       b.Endereco.Complemento,
                       b.Endereco.Bairro,
                       b.Endereco.Cidade,
                       b.Endereco.CEP,
                       b.Endereco.Estado));

            CreateMap<FornecedorModel, ResponseFornecedorOut>().ReverseMap();
            CreateMap<Domain.Entities.Fornecedor, ResponseFornecedorOut>().ReverseMap();
        }
    }
}
