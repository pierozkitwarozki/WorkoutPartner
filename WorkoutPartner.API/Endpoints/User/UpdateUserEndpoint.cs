using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.DTO.UpdateUser;
using WorkoutPartner.Domain.ResultType.Errors;
using WorkoutPartner.Infrastructure.Routes;

namespace WorkoutPartner.API.Endpoints.User;

public class UpdateUserEndpoint : IEndpointBase
{
    public string Group => RouteGroupNames.User;
    public string Route => RouteNames.Update;
    public RouteHandlerBuilder MapEndpoint(RouteGroupBuilder builder)
    {
        return builder.MapPut(Route, async (
            [FromBody] UpdateUserRequest payload,
            HttpContext context,
            [FromServices] IMediator mediator) =>
        {
            var command = new UpdateUserCommand
            {
                Principal = context.User,
                Data = payload
            };

            var result = await mediator.Send(command);

            return result switch
            {
                { IsFailure: true, Error.Type: nameof(NotFoundError) } => Results.NotFound(result.Error.Description),
                { IsFailure: true, Error.Type: nameof(ValidationError) } => Results.UnprocessableEntity(result.Error
                    .Description),
                _ => result.IsFailure ? Results.BadRequest() : TypedResults.Ok()
            };
        });
        //.RequireAuthorization();
    }
}