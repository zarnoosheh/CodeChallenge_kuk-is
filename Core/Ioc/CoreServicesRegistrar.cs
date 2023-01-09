using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Ioc;

public static class CoreServicesRegistrar
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CoreServicesRegistrar).Assembly);

        services.AddValidatorsFromAssembly(typeof(CoreServicesRegistrar).Assembly);

        return services;
    }
}