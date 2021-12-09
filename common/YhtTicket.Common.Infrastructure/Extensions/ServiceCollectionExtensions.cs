using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YhtTicket.Common.Infrastructure.Services;

namespace YhtTicket.Common.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddMediatR(Assembly.GetEntryAssembly());
        }
    }
}
