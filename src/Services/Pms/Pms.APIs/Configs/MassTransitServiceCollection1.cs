using Core.EventBus.Interfaces;
using Core.EventBus.Masstransit;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Pms.APIs.Configs
{

    //static bool? _isRunningInContainer;

    //static bool IsRunningInContainer =>
    //_isRunningInContainer ??= bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), out var inContainer) && inContainer;


    public static class MassTransitServiceCollection1
    {
        public static void AddMassTransitConfig(this IServiceCollection services, IConfiguration configuration, Action<MassTransitEventBusOptions>? setupAction = null)
        {
            var options = new MassTransitEventBusOptions();
            if (setupAction != null)
                setupAction(options);

            var config = new MassTransitConfiguration();
            configuration.GetSection(MassTransitConfiguration.SectionName).Bind(config);

            services.AddMassTransit(x =>
            {
                //x.AddConsumers(typeof(PaymentCreatedHandler).Assembly);

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(config.RabbitMqHostName ?? throw new NullReferenceException("The host has not been specififed for RabbitMQ"), x =>
                    {
                        x.Username(config.RabbitMqUsername ?? throw new NullReferenceException("The username has not been specififed for RabbitMQ"));
                        x.Password(config.RabbitMqPassword ?? throw new NullReferenceException("The password has not been specififed for RabbitMQ"));
                    });

                    // Set up receiver endpoint for the ProductCreated event
                    // using the contancts from the messagebus library
                    // rabbitSettings.QueueName => service-b
                    cfg.ConfigureEndpoints(ctx);

                    // Add all consumers here...

                });
                var entryAssembly = Assembly.GetEntryAssembly();

                x.AddConsumers(entryAssembly);
                x.AddSagaStateMachines(entryAssembly);
                x.AddSagas(entryAssembly);
                x.AddActivities(entryAssembly);

            });

            //services.AddMassTransit(x =>
            //{
            //    x.SetKebabCaseEndpointNameFormatter();
            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        x.SetKebabCaseEndpointNameFormatter();
            //        //x.UsingRabbitMq((context, cfg) =>
            //        //{
            //        //    cfg.ConfigureEndpoints(context);
            //        //    cfg.Host(config.RabbitMqHostName, config.RabbitMqVirtualHost, h =>
            //        //    {
            //        //        h.Username(config.RabbitMqUsername);
            //        //        h.Password(config.RabbitMqPassword);
            //        //    });
            //        //});

            //        //x.UsingRabbitMq((context, cfg) =>
            //        //{
            //        //    cfg.Host("localhost", "/", h => {
            //        //        h.Username("guest");
            //        //        h.Password("guest");
            //        //    });

            //        //    cfg.ConfigureEndpoints(context);
            //        //});
            //        //x.AddDelayedMessageScheduler();

            //        // By default, sagas are in-memory, but should be changed to a durable
            //        // saga repository.
            //        x.SetInMemorySagaRepositoryProvider();

            //        var entryAssembly = Assembly.GetEntryAssembly();

            //        x.AddConsumers(entryAssembly);
            //        x.AddSagaStateMachines(entryAssembly);
            //        x.AddSagas(entryAssembly);
            //        x.AddActivities(entryAssembly);

            //        x.UsingRabbitMq((context, cfg) =>
            //        {
            //            cfg.Host(config.RabbitMqHostName, config.RabbitMqVirtualHost, h =>
            //                {
            //                    h.Username(config.RabbitMqUsername);
            //                    h.Password(config.RabbitMqPassword);
            //                });

            //            cfg.UseDelayedMessageScheduler();

            //            //cfg.ConfigureEndpoints(context);

            //            cfg.ReceiveEndpoint("general-queue", e =>
            //            {
            //                e.ConfigureConsumers(context);
            //            });
            //        });



            //        foreach (var consumerItem in options.GetConsumersInfo())
            //        {
            //            x.AddConsumer(consumerItem.consumerType, consumerItem.consumerDefenationType);
            //        }
            //    });
            //});

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
