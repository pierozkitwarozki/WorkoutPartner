using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Environment = WorkoutPartner.Domain.Configuration.Environment;

namespace WorkoutPartner.Infrastructure.Configuration;

public static class ServicesInstaller
{
    /// <summary>
    /// Install all necessary services for the application
    /// </summary>
    /// <param name="serviceCollection">Service collection</param>
    /// <param name="configuration">IConfiguration from app builder</param>
    /// <param name="environment">Environment enum</param>
    /// <returns>Updated service collection</returns>
    public static IServiceCollection ConfigureServices(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration,
        Environment environment)
    {
        return serviceCollection
            .InstallDatabase(configuration, environment)
            .InstallAuth()
            .InstallValidators()
            .InstallMediator();
    }
}