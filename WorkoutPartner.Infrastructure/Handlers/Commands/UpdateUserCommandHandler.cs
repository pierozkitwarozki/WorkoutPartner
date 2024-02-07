using MediatR;
using Microsoft.AspNetCore.Identity;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.UpdateUser;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Domain.ResultType.Errors;

namespace WorkoutPartner.Infrastructure.Handlers.Commands;

public class UpdateUserCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<UpdateUserCommand, Result<UpdateUserResponse>>
{
    public async Task<Result<UpdateUserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.GetUserAsync(request.Principal);

        if (user is null)
        {
            return Result<UpdateUserResponse>.Failure(NotFoundError.New(nameof(ApplicationUser)));
        }

        if (request.Data.Height is not null)
        {
            user.Height = request.Data.Height;
        }

        if (request.Data.Weight is not null)
        {
            user.Weight = request.Data.Weight;
        }

        if (!string.IsNullOrWhiteSpace(request.Data.UserName))
        {
            user.UserName = request.Data.UserName;
        }

        await userManager.UpdateAsync(user);

        return Result<UpdateUserResponse>.Success(new UpdateUserResponse(true));
    }
}