using Microsoft.Extensions.DependencyInjection;
using WorkoutPartner.Application.Services;
using WorkoutPartner.Infrastructure.Services;

namespace WorkoutPartner.Infrastructure.Configuration;

public static class ServicesInstaller
{
    public static IServiceCollection InstallServices(this IServiceCollection services)
    {
        services.AddScoped<IDateTimeService, DateTimeService>();
        return services;
    }
}