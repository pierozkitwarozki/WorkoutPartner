using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Extensions;
using WorkoutPartner.Domain.DTO.ExerciseAdd;
using WorkoutPartner.Domain.ResultType.Errors;
using WorkoutPartner.Domain.Routes;

namespace WorkoutPartner.API.Endpoints.Exercise;

public class ExerciseAddEndpoint : IEndpointBase
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

                return result switch
                {
                    { IsFailure: true, Error.Type: nameof(ValidationError) } => Results.UnprocessableEntity(result.Error
                        .Description),
                    _ => result.IsFailure ? Results.BadRequest() : TypedResults.Ok(result.Value)
                };
            })
            .RequireAuthorization();
    }
}