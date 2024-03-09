using MediatR;
using Microsoft.AspNetCore.Identity;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.UserUpdate;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Domain.ResultType.Errors;

namespace WorkoutPartner.Infrastructure.Handlers.Commands;

public class UserUpdateCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<UserUpdateCommand, Result<UserUpdateResponse>>
{
    public async Task<Result<UserUpdateResponse>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.GetUserAsync(request.Principal);

        if (user is null)
        {
            return Result<UserUpdateResponse>.Failure(NotFoundError.New(nameof(ApplicationUser)));
        }

        if (request.Request.Height is not null)
        {
            user.Height = request.Request.Height;
        }

        if (request.Request.Weight is not null)
        {
            user.Weight = request.Request.Weight;
        }

        if (!string.IsNullOrWhiteSpace(request.Request.UserName))
        {
            user.UserName = request.Request.UserName;
        }

        await userManager.UpdateAsync(user);

        return Result<UserUpdateResponse>.Success(new UserUpdateResponse(true));
    }
}