using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using SGL.Resource.Util;
using SGL.Util.Exceptions;
using SGL.Util.Extensions;
using SGL.Util.Helpers.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SGL.Resource.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                WriteToLog(exception);
                await ResultException(exception, context);
            }
        }

        private void WriteToLog(Exception exception)
        {
            var innerException = exception.InnerException?.ToString();
            var stackTrace = exception.StackTrace?.ToString();
            LogHelper.AddLog(LogLevel.Error, @$"
			############### - Message - #############
			{exception.Message}
			##############  - InnerException - #############
			{innerException}
			##############  - StackTrace - #############
			{stackTrace}");
        }

        private async Task ResultException(Exception exception, HttpContext context)
        {
            context.Response.Headers.Add("Content-Type", "application/json");
            var erros = new Dictionary<string, string[]>();
            var exceptionMessage = String.Empty;

            if (exception is ApiException)
            {
                var apiException = exception as ApiException;
                context.Response.StatusCode = (int)apiException.HttpStatusCode;
                erros = apiException.Errors;
                exceptionMessage = exception.Message;
            }
            else if (exception is Refit.ApiException)
            {
                context.Response.StatusCode = (int)(exception as Refit.ApiException).StatusCode;
                var exceptionRefit = exception as Refit.ApiException;

                JObject obj = JObject.Parse(exceptionRefit.Content);
                var message = obj["message"]?.ToString();
                exceptionMessage = string.IsNullOrEmpty(message) ? exception.Message : message;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                exceptionMessage = exception.Message;
            }

            await context.Response.WriteAsync(ObjectResultError(exceptionMessage, context.Response.StatusCode, erros).SerializeObject());
        }
        private DefaultResult ObjectResultError(string message, int statusCode, Dictionary<string, string[]> errors)
        {
            if (errors?.Any() != true)
            {
                errors = new Dictionary<string, string[]>
                {
                    {"Exception", new string[]{ message } }
                };
            }

            return new DefaultResult(statusCode, message: message, success: false, errors);
        }
    }
}
