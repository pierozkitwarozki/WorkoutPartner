using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.DTO.ExerciseSearch;
using WorkoutPartner.Domain.ResultType.Errors;
using WorkoutPartner.Infrastructure.Routes;

namespace WorkoutPartner.API.Endpoints.Exercise;

public class ExerciseSearchEndpoint : IEndpointBase
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
                    var command = new ExerciseSearchCommand
                    {
                        Request = payload
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