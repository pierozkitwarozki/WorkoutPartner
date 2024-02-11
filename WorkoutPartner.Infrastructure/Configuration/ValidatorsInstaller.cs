using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace WorkoutPartner.Infrastructure.Configuration;

internal static class ValidatorsInstaller
{
    internal static IServiceCollection InstallValidators(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssemblyContaining<MediatorEntryPoint>();
    }
}