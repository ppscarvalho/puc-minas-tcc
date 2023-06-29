using AutoMapper;
using SGL.Cliente.Core.Application.Commands.Cliente;
using SGL.Cliente.Core.Application.Models;
using SGL.Resource.Domain.ValueObjects;
using SGL.MessageQueue.Models.Cliente;

namespace SGL.Cliente.Core.Application.AutoMappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Adicioinar Cliente Command
            CreateMap<ClienteModel, AdicionarClienteCommand>().ReverseMap();
            CreateMap<AdicionarClienteCommand, Domain.Entities.Cliente>().ConstructUsing(b => new Domain.Entities.Cliente(
                    b.Nome,
                    b.CPF,
                    b.Celular,
                    b.DataNascimento,
                    new Email(b.EnderecoEmail),
                    new Endereco(b.Logradouro,
                    b.Numero,
                    b.Complemento,
                    b.Bairro,
                    b.Cidade,
                    b.CEP,
                    b.Estado)));

            CreateMap<Domain.Entities.Cliente, AdicionarClienteCommand>().ConstructUsing(b => new AdicionarClienteCommand(
                       b.Id,
                       b.Nome,
                       b.CPF,
                       b.Celular,
                       b.DataNascimento,
                       b.Email.EnderecoEmail,
                       b.Endereco.Logradouro,
                       b.Endereco.Numero,
                       b.Endereco.Complemento,
                       b.Endereco.Bairro,
                       b.Endereco.Cidade,
                       b.Endereco.CEP,
                       b.Endereco.Estado));

            //Atualizar Cliente Command
            CreateMap<ClienteModel, AtualizarClienteCommand>().ReverseMap();
            CreateMap<AtualizarClienteCommand, Domain.Entities.Cliente>().ConstructUsing(b => new Domain.Entities.Cliente(
                    b.Nome,
                    b.CPF,
                    b.Celular,
                    b.DataNascimento,
                    new Email(b.NomeEmail),
                    new Endereco(b.Logradouro,
                    b.Numero,
                    b.Complemento,
                    b.Bairro,
                    b.Cidade,
                    b.CEP,
                    b.Estado)));

            CreateMap<Domain.Entities.Cliente, ClienteModel>().ConstructUsing(b => new ClienteModel(
                       b.Id,
                       b.Nome,
                       b.CPF,
                       b.Celular,
                       b.DataNascimento,
                       b.Email.EnderecoEmail,
                       b.Endereco.Logradouro,
                       b.Endereco.Numero,
                       b.Endereco.Complemento,
                       b.Endereco.Bairro,
                       b.Endereco.Cidade,
                       b.Endereco.CEP,
                       b.Endereco.Estado));

            CreateMap<ClienteModel, ResponseClienteOut>().ReverseMap();
        }
    }
}
