using Core.EventBus.Interfaces;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.EventBus.Masstransit
{
    public static class MassTransitServiceCollection
    {
        public static void AddMassTransitConfigAsync(this IServiceCollection services, IConfiguration configuration, Action<MassTransitEventBusOptions> setupAction = null)
        {
            var options = new MassTransitEventBusOptions();
            if (setupAction != null)
                setupAction(options);

            var config = new MassTransitConfiguration();
            configuration.GetSection(MassTransitConfiguration.SectionName).Bind(config);


            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();
                x.UsingRabbitMq((context, cfg) =>
                {
                    x.SetKebabCaseEndpointNameFormatter();
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.ConfigureEndpoints(context);
                        cfg.Host(config.RabbitMqHostName, config.RabbitMqVirtualHost, h =>
                        {
                            h.Username(config.RabbitMqUsername);
                            h.Password(config.RabbitMqPassword);
                        });
                    });

                    foreach (var consumerItem in options.GetConsumersInfo())
                    {
                        x.AddConsumer(consumerItem.consumerType, consumerItem.consumerDefenationType);
                    }
                });
            });

            services.AddTransient<IEventPublisher, EventPublisher>();
            services.Configure<MassTransitConfiguration>(configuration.GetSection(MassTransitConfiguration.SectionName));

            foreach (var handlerType in options.GetConsumersInfo())
            {
                services.AddTransient(handlerType.handlerType);
            }

            foreach (var behavior in options.GetPipelineBehaviors())
            {
                services.AddTransient(typeof(IMassTransitEventBusPipelineBehaviour), behavior);
            }
        }
    }
}
