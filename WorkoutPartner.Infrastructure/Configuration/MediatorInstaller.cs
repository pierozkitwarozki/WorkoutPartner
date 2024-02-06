using Microsoft.Extensions.DependencyInjection;

namespace WorkoutPartner.Infrastructure.Configuration;

internal static class MediatorInstaller
{
    internal static IServiceCollection InstallMediator(this IServiceCollection services)
    {
        return services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(MediatorEntryPoint).Assembly);
        });
    }
}