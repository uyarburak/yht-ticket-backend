namespace YhtTicket.Common.Infrastructure.Exceptions
{
    public class KeyNotFoundException : ApiException
    {
        public KeyNotFoundException(string errorCode, string message) : base(System.Net.HttpStatusCode.NotFound, errorCode, message)
        {

        }
    }
}
