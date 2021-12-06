using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace YhtTicket.Common.Infrastructure.Exceptions
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
            catch (ApiException e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)e.HttpStatusCode;

                var result = JsonSerializer.Serialize(new { message = e.Message, code = e.ErrorCode });
                await response.WriteAsync(result);
            }
            catch (Exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                var result = JsonSerializer.Serialize(new { message = "Beklenmeyen hata", code = "INTERNAL_ERROR" });
                await response.WriteAsync(result);
            }
        }
    }
}
