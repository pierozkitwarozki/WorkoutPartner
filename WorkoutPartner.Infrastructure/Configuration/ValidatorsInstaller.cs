using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace WorkoutPartner.Infrastructure.Configuration;

public static class ValidatorsInstaller
{
    public static IServiceCollection InstallValidators(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssemblyContaining<MediatorEntryPoint>();
    }
}