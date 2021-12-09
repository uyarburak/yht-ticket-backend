using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using YhtTicket.Common.MassTransit.Producer;

namespace YhtTicket.Common.MassTransit.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration, Action<IRabbitMqBusFactoryConfigurator> configure = null)
        {
            services.AddSingleton<IMessageProducer, MessageProducer>();
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(configuration.GetValue<string>("RabbitMq.Url")), c =>
                    {
                        c.Username(configuration.GetValue<string>("RabbitMq.Username"));
                        c.Password(configuration.GetValue<string>("RabbitMq.Password"));
                    });

                    cfg.ConfigureEndpoints(context);

                    if (configure is not null)
                    {
                        configure(cfg);
                    }
                });
            });
        }
    }
}
