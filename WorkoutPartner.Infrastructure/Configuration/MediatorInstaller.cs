using Microsoft.Extensions.DependencyInjection;
using WorkoutPartner.Infrastructure.PipelineBehaviors;

namespace WorkoutPartner.Infrastructure.Configuration;

internal static class MediatorInstaller
{
    /// <summary>
    /// Registers all mediator handlers.
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <returns>Updated service collection</returns>
    internal static IServiceCollection InstallMediator(this IServiceCollection services)
    {
        return services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(MediatorEntryPoint).Assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
    }
}