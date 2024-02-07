using System.Security.Claims;
using MediatR;
using WorkoutPartner.Domain.DTO.UpdateUser;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Commands;

public class UpdateUserCommand : IRequest<Result<UpdateUserResponse>>
{
    public ClaimsPrincipal Principal { get; init; }
    public UpdateUserRequest Data { get; init; }
}