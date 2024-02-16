namespace WorkoutPartner.API.Endpoints.Configuration;

public interface IEndpointBase
{
    public string Group { get; }
    public string Route { get; }

    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder);
}