using MediatR;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Infrastructure.Routes;

namespace WorkoutPartner.API.Endpoints.Auth;

public class SignInEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.Auth;
    public string Route => RouteNames.SignIn;
    
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost(Route, 
            async (IMediator mediator) =>
            {
                await mediator.Send(new SignInCommand());
                return TypedResults.Ok(100);
            });
    }
}