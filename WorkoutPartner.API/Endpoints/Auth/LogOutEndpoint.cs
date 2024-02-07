using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.Infrastructure.Routes;

namespace WorkoutPartner.API.Endpoints.Auth;

public class LogOutEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.Auth;
    public string Route => RouteNames.LogOut;
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost("/logout", 
                async ([FromServices] SignInManager<IdentityUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return Results.Ok();
            })
            .RequireAuthorization();
    }
}