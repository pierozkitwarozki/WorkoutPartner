using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.API.Endpoints.Configuration;
using WorkoutPartner.Application.Extensions;
using WorkoutPartner.Application.Queries;
using WorkoutPartner.Domain.DTO.Queries.ExerciseSearch;
using WorkoutPartner.Domain.DTO.Queries.WorkoutPlanSchemaSearch;
using WorkoutPartner.Domain.Routes;
using WorkoutPartner.Infrastructure.Extensions;

namespace WorkoutPartner.API.Endpoints.Features.WorkoutPlanSchema;

public class WorkoutPlanSchemaSearchEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.WorkoutPlanSchema;
    public string Route => RouteNames.Search;
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapGet(Route,
                async (
                    [AsParameters] WorkoutPlanSchemaSearchRequest request,
                    ClaimsPrincipal user,
                    [FromServices] IMediator mediator) =>
                {
                    var query = new WorkoutPlanSchemaSearchQuery
                    {
                        Request = request,
                        UserId = user.GetUserNameIdentifier()
                    };

                    var result = await mediator.Send(query);

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