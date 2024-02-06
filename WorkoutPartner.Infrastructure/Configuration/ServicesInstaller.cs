using Microsoft.Extensions.DependencyInjection;

namespace WorkoutPartner.Infrastructure.Configuration;

public static class ServicesInstaller
{
    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection.InstallMediator();
    }
}