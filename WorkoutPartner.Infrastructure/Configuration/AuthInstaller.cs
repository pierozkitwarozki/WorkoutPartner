using Microsoft.Extensions.DependencyInjection;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Infrastructure.Database;

namespace WorkoutPartner.Infrastructure.Configuration;

internal static class AuthInstaller
{
    internal static IServiceCollection InstallAuth(this IServiceCollection services)
    {
        // TODO: Play with some features here
        services
            .AddAuthorization()
            .AddIdentityApiEndpoints<ApplicationUser>()
            .AddEntityFrameworkStores<DatabaseContext>();

        return services;
    }
}