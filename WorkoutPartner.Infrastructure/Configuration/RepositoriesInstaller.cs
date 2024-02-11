using Microsoft.Extensions.DependencyInjection;
using WorkoutPartner.Application.Repositories.Implementations;
using WorkoutPartner.Application.Repositories.Interfaces;

namespace WorkoutPartner.Infrastructure.Configuration;

internal static class RepositoriesInstaller
{
    internal static IServiceCollection InstallRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        return services;
    }
}