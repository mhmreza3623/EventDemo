using Core.EventBus.Interfaces;
using MassTransit;
using MassTransit.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.EventBus.Masstransit
{
    public static class MassTransitServiceCollection
    {
        public static void AddMassTransitConfigAsync(this IServiceCollection services, IConfiguration configuration, Action<MassTransitEventBusOptions>? setupAction = null)
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
                    cfg.AutoStart = true;

                    cfg.UseInstrumentation();

                    if (HostMetadataCache.IsRunningInContainer)
                        cfg.Host(config.RabbitMqHostName ?? throw new NullReferenceException("The host has not been specififed for RabbitMQ"), x =>
                                               {
                                                   x.Username(config.RabbitMqUsername ?? throw new NullReferenceException("The username has not been specififed for RabbitMQ"));
                                                   x.Password(config.RabbitMqPassword ?? throw new NullReferenceException("The password has not been specififed for RabbitMQ"));
                                               });
                    cfg.UseDelayedMessageScheduler();

                    cfg.ConfigureEndpoints(context);
                });
                foreach (var consumerItem in options.GetConsumersInfo())
                {
                    x.AddConsumer(consumerItem.consumerType, consumerItem.consumerDefenationType);
                }


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
