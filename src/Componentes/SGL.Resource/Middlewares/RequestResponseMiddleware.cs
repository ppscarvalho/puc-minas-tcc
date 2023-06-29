using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace SGL.Resource.Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            EnableReadRequest(context.Request);
            await EnableReadResponse(context);
        }
        private void EnableReadRequest(HttpRequest request)
        {
            request.EnableBuffering();
        }
        private async Task EnableReadResponse(HttpContext context)
        {
            Stream originalBody = context.Response.Body;
            try
            {
                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;
                    await _next(context);
                    memStream.Position = 0;
                    string responseBody = new StreamReader(memStream).ReadToEnd();
                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                }
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }
    }
}
