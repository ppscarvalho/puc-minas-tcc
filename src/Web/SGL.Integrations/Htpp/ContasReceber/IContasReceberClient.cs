﻿using SGL.Integrations.ViewModels;
using SGL.Util.ApiClient;

namespace SGL.Integrations.Htpp.ContasReceber
{
    public interface IContasReceberClient : IApiClientBase
    {
        Task<IEnumerable<ContasReceberViewModel>> ObterTodasContasRecebers();
        Task<ContasReceberViewModel> ObterContasReceberPorId(Guid id);
    }
}