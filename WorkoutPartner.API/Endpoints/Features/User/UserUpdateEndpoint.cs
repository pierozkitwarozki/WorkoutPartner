using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.API.Endpoints.Configuration;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.DTO.UserUpdate;
using WorkoutPartner.Domain.ResultType.Errors;
using WorkoutPartner.Domain.Routes;
using WorkoutPartner.Infrastructure.Extensions;

namespace WorkoutPartner.API.Endpoints.Features.User;

public sealed class UserUpdateEndpoint : IEndpointBase
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

            if (result.IsNotFound())
            {
                return Results.NotFound(result.Error);
            }
            if (result.IsValidationError())
            {
                return Results.UnprocessableEntity(result.Error);
            }

            return result.IsFailure 
                ? Results.BadRequest(result.Error) 
                : TypedResults.Ok(result.Value);
        })
        .RequireAuthorization();
    }
}