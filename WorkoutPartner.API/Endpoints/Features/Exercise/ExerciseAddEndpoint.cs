using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.API.Endpoints.Configuration;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Extensions;
using WorkoutPartner.Domain.DTO.Commands.ExerciseAdd;
using WorkoutPartner.Domain.Routes;
using WorkoutPartner.Infrastructure.Extensions;

namespace WorkoutPartner.API.Endpoints.Features.Exercise;

public sealed class ExerciseAddEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.Exercise;
    public string Route => RouteNames.Add;
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost(Route,
            async (
                [FromBody] ExerciseAddRequest payload,
                ClaimsPrincipal user,
                [FromServices] IMediator mediator) =>
            {
                var command = new ExerciseAddCommand
                {
                    Request = payload,
                    UserId = user.GetUserNameIdentifier()
                };

                var result = await mediator.Send(command);

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