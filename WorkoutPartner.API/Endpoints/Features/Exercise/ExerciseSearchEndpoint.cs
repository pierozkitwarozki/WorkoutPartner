using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.API.Endpoints.Configuration;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Queries;
using WorkoutPartner.Domain.DTO.ExerciseSearch;
using WorkoutPartner.Domain.Routes;
using WorkoutPartner.Infrastructure.Extensions;

namespace WorkoutPartner.API.Endpoints.Features.Exercise;

public sealed class ExerciseSearchEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.Exercise;
    public string Route => RouteNames.Search;
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapGet(Route,
                async (
                    [AsParameters] ExerciseSearchRequest payload,
                    [FromServices] IMediator mediator) =>
                {
                    var command = new ExerciseSearchQuery
                    {
                        Request = payload
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