using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace YhtTicket.Common.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetEntryAssembly());
        }
    }
}
