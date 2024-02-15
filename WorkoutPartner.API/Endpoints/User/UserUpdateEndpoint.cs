using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.DTO.UserUpdate;
using WorkoutPartner.Domain.ResultType.Errors;
using WorkoutPartner.Domain.Routes;

namespace WorkoutPartner.API.Endpoints.User;

public class UserUpdateEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.User;
    public string Route => RouteNames.Update;
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPut(Route, async (
            [FromBody] UserUpdateRequest payload,
            ClaimsPrincipal user,
            [FromServices] IMediator mediator) =>
        {
            var command = new UserUpdateCommand
            {
                Principal = user,
                Request = payload
            };

            var result = await mediator.Send(command);

            return result switch
            {
                { IsFailure: true, Error.Type: nameof(NotFoundError) } => Results.NotFound(result.Error.Description),
                { IsFailure: true, Error.Type: nameof(ValidationError) } => Results.UnprocessableEntity(result.Error
                    .Description),
                _ => result.IsFailure ? Results.BadRequest() : TypedResults.Ok(result.Value)
            };
        })
        .RequireAuthorization();
    }
}