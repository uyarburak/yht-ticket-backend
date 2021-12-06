namespace YhtTicket.Common.Infrastructure.Exceptions
{
    public class ValidationException : ApiException
    {
        public ValidationException(string errorCode, string message) : base(System.Net.HttpStatusCode.BadRequest, errorCode, message)
        {

        }
    }
}
