using Core.EventBus.Handlers;
using Core.EventBus.Interfaces;
using MassTransit;
using MassTransit.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Core.EventBus.Masstransit
{
    public static class MassTransitServiceCollection
    {
        public static void AddMassTransitConsumers(this IServiceCollection services, IConfiguration configuration,
            Action<MassTransitEventBusOptions>? handlerAction = null)
        {

            var handlers = new MassTransitEventBusOptions();
            if (handlerAction != null)
                handlerAction(handlers);

            var config = new MassTransitConfiguration();
            configuration.GetSection(MassTransitConfiguration.SectionName).Bind(config);

            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.AutoStart = true;
                    //cfg.UseInstrumentation();
                    if (HostMetadataCache.IsRunningInContainer)
                        cfg.Host(config.RabbitMqHostName ?? throw new NullReferenceException("The host has not been specififed for RabbitMQ"), x =>
                        {
                            x.Username(config.RabbitMqUsername ?? throw new NullReferenceException("The username has not been specififed for RabbitMQ"));
                            x.Password(config.RabbitMqPassword ?? throw new NullReferenceException("The password has not been specififed for RabbitMQ"));
                        });

                    cfg.UseDelayedMessageScheduler();
                    cfg.ConfigureEndpoints(context);
                });

                foreach (var consumerItem in handlers.GetConsumersInfo())
                {
                    x.AddConsumer(consumerItem.EventHandler);
                }
            });
            services.AddTransient<IEventPublisher, EventPublisher>();
        }
    }
}
