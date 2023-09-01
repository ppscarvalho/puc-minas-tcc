namespace SGL.Integrations.Htpp.Cliente
{
    public class HttpClienteDelegatingHandler : DelegatingHandler
    {
        //private readonly ITokenAcquisitionService _tokenAcquisitionService;

        //public HttpClienteDelegatingHandler(ITokenAcquisitionService tokenAcquisitionService)
        //{
        //    _tokenAcquisitionService = tokenAcquisitionService;
        //}

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var token = GetHeader("authorization", true)?.Replace("Bearer ", "");
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");

            //var context = request.GetPolicyExecutionContext();
            //var clientId = context?["access_token"] as string ?? throw new InvalidOperationException("No clientId found in execution context");

            //var token = await _tokenAcquisitionService.GetToken(clientId);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }

    public interface ITokenAcquisitionService
    {
        Task<string> GetToken(string clientId);
    }
}
