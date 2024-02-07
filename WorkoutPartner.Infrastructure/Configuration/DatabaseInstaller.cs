using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkoutPartner.Infrastructure.Database;
using Environment = WorkoutPartner.Domain.Configuration.Environment;

namespace WorkoutPartner.Infrastructure.Configuration;

internal static class DatabaseInstaller
{
    private const string AssemblyName = "WorkoutPartner.API";
    /// <summary>
    /// Ads database connection based on given environment
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configuration">IConfiguration from app builder</param>
    /// <param name="environment">Environment enum</param>
    /// <returns>Updated service collection</returns>
    internal static IServiceCollection InstallDatabase(
        this IServiceCollection services, 
        IConfiguration configuration,
        Environment environment)
    {
        return environment == Environment.Development 
            ? InstallSqlite(services, configuration) 
            : InstallPostgres(services, configuration);
    } 
    
    /// <summary>
    /// Install database for development
    /// </summary>
    private static IServiceCollection InstallSqlite(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Sqlite");
        services.AddDbContext<DatabaseContext>(options
            => options
                .UseSqlite(connectionString, 
                c => c.MigrationsAssembly(AssemblyName)));
        return services;
    }

    /// <summary>
    /// Install database for production
    /// </summary>
    private static IServiceCollection InstallPostgres(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");
        services.AddDbContext<DatabaseContext>(options
            => options.UseNpgsql(connectionString, 
                c => c.MigrationsAssembly(AssemblyName)));
        return services;
    }
}