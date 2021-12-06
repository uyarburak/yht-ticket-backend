using System;
using System.Net;

namespace YhtTicket.Common.Infrastructure.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }
        public string ErrorCode { get; }

        public ApiException(HttpStatusCode httpStatusCode, string errorCode, string message, Exception innerException = default) : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
            ErrorCode = errorCode;
        }
    }
}
