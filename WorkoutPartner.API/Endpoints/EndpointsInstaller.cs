using System.Collections.Immutable;
using System.Reflection;
using WorkoutPartner.Domain.Database.Models;

namespace WorkoutPartner.API.Endpoints;

public static class EndpointsInstaller
{
    public static void MapEndpoints(this WebApplication application)
    {
        var endpointGroups = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IEndpointBase).IsAssignableFrom(t) && !t.IsInterface)
            .Select(type => Activator.CreateInstance(type) as IEndpointBase)
            .GroupBy(e => e?.Group);

        foreach (var endpointGroup in endpointGroups)
        {
            ArgumentNullException.ThrowIfNull(endpointGroup.Key);
            
            var groupBuilder = application.MapGroup(endpointGroup.Key);
            var endpoints = endpointGroup.ToImmutableArray();

            MapEndpointsInGroup(groupBuilder, endpoints);
        }
        
        application.MapIdentityApi<User>();
    }

    private static void MapEndpointsInGroup(RouteGroupBuilder group, ImmutableArray<IEndpointBase?>? endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);
        
        foreach (var endpoint in endpoints)
        {
            endpoint?
                .MapEndpoint(group)
                .WithOpenApi();
        }
    }
}