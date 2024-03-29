﻿using AutoMapper;
using SGL.Integrations.Htpp.Fornecedor;
using SGL.Integrations.Interfaces;
using SGL.Integrations.ViewModels;
using SGL.Resource.Util;

namespace SGL.Integrations.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorClient _fornecedorClient;
        public FornecedorService(IMapper mapper, IFornecedorClient fornecedorClient)
        {
            _mapper = mapper;
            _fornecedorClient = fornecedorClient;
        }

        public async Task<FornecedorViewModel> ObterFornecedorPorId(Guid id, string token)
        {
            return await _fornecedorClient.ObterFornecedorPorId(id, token);
        }

        public async Task<IEnumerable<FornecedorViewModel>> ObterTodosFornecedores(string token)
        {
            return await _fornecedorClient.ObterTodosFornecedores(token);
        }

        public IEnumerable<EstadoViewModel> TodosEstados()
        {
            var states = new EstadoViewModel();
            return states.TodosEstados();
        }

        public async Task<DefaultResult> Adicionar(FornecedorViewModel fornecedorViewModel, string token)
        {
            return await _fornecedorClient.Adicionar(fornecedorViewModel, token);
        }

        public async Task<DefaultResult> Atualizar(FornecedorViewModel fornecedorViewModel, string token)
        {
            return await _fornecedorClient.Atualizar(fornecedorViewModel, token);
        }
    }
}
