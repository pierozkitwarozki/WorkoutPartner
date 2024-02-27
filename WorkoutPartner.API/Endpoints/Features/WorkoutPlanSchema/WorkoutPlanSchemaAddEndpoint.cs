using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.API.Endpoints.Configuration;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Extensions;
using WorkoutPartner.Domain.DTO.ExerciseSchemaAdd;
using WorkoutPartner.Domain.DTO.WorkoutPlanSchemaAdd;
using WorkoutPartner.Domain.Routes;
using WorkoutPartner.Infrastructure.Extensions;

namespace WorkoutPartner.API.Endpoints.Features.WorkoutPlanSchema;

public class WorkoutPlanSchemaAddEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.WorkoutPlanSchema;
    public string Route => RouteNames.Add;
    
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPost(Route,
                async (
                    [FromBody] WorkoutPlanSchemaAddRequest payload,
                    ClaimsPrincipal user,
                    [FromServices] IMediator mediator) =>
                {
                    var command = new WorkoutPlanSchemaAddCommand()
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