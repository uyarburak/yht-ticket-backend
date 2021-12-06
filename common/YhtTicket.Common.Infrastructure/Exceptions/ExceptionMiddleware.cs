using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace YhtTicket.Common.Infrastructure.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException e)
            {
                LogException(e);
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)e.HttpStatusCode;

                var result = JsonSerializer.Serialize(new { message = e.Message, code = e.ErrorCode });
                await response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                LogException(ex);
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                var result = JsonSerializer.Serialize(new { message = "Beklenmeyen hata", code = "INTERNAL_ERROR" });
                await response.WriteAsync(result);
            }
        }

        private void LogException(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }
}
