namespace YhtTicket.Common.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public string GetCurrentUsername()
        {
            return "burak"; // TODO get from access token
        }
    }
}
