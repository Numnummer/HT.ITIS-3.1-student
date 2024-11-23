using Dotnet.Homeworks.Mailing.API.Configuration;
using Dotnet.Homeworks.Mailing.API.Consumers;
using MassTransit;

namespace Dotnet.Homeworks.Mailing.API.ServicesExtensions;

public static class AddMasstransitRabbitMqExtensions
{
    public static IServiceCollection AddMasstransitRabbitMq(this IServiceCollection services,
        RabbitMqConfig rabbitConfiguration)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<EmailConsumer>();
            x.UsingRabbitMq((context, config) =>
            {
                config.Host(rabbitConfiguration.Hostname, "/", h =>
                {
                    h.Username(rabbitConfiguration.Username);
                    h.Password(rabbitConfiguration.Password);
                });

                config.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}