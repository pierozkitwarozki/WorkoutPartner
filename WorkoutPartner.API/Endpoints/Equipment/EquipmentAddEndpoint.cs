using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.DTO.EquipmentAdd;
using WorkoutPartner.Domain.ResultType.Errors;
using WorkoutPartner.Infrastructure.Routes;

namespace WorkoutPartner.API.Endpoints.Equipment;

public class ExerciseAddEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.Equipment;
    public string Route => RouteNames.Add;
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost(Route,
            async (
                [FromBody] EquipmentAddRequest payload,
                [FromServices] IMediator mediator) =>
            {
                var command = new EquipmentAddCommand()
                {
                    Request = payload
                };

                var result = await mediator.Send(command);

                return result switch
                {
                    { IsFailure: true, Error.Type: nameof(ValidationError) } => Results.UnprocessableEntity(result.Error
                        .Description),
                    _ => result.IsFailure ? Results.BadRequest() : TypedResults.Ok(result)
                };
            })
            .RequireAuthorization();
    }
}