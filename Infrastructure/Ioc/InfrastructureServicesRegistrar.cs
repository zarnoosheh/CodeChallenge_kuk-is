using Core.Contracts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ioc;

public static class InfrastructureServicesRegistrar
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();

        services.AddDbContext<ApplicationContext>(o =>
            o.UseInMemoryDatabase("CodeChallenge"));

        services.AddScoped<IUnitOfWork>(f => f.GetRequiredService<ApplicationContext>());
        return services;
    }
}