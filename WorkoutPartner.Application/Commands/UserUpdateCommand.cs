using System.Security.Claims;
using MediatR;
using WorkoutPartner.Domain.DTO.Commands.UserUpdate;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Commands;

public class UserUpdateCommand : IRequest<Result<UserUpdateResponse>>
{
    public required ClaimsPrincipal Principal { get; init; }
    public required UserUpdateRequest Request { get; init; }
}