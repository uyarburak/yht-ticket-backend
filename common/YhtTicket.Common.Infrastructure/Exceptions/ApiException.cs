using System;
using System.Net;

namespace YhtTicket.Common.Infrastructure.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }
        public string ErrorCode { get; }

        public ApiException(HttpStatusCode httpStatusCode, string errorCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            ErrorCode = errorCode;
        }
    }
}
