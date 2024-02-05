using WorkoutPartner.Infrastructure.Routes;

namespace WorkoutPartner.API.Endpoints.Auth;

public class SignUpEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.Auth;
    public string Route => RouteNames.SignUp;
    
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost(Route, async () =>
        {
            await Task.Delay(100);
            return TypedResults.Ok(100);
        });
    }
}