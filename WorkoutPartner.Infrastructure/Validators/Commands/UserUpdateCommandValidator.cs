using FluentValidation;
using WorkoutPartner.Application.Commands;

namespace WorkoutPartner.Infrastructure.Validators.Commands;

public class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
{
    public UserUpdateCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull();

        RuleFor(x => x.Request.Height)
            .GreaterThanOrEqualTo(30)
            .LessThanOrEqualTo(350);

        RuleFor(x => x.Request.Weight)
            .GreaterThanOrEqualTo(20)
            .LessThanOrEqualTo(1000);

        RuleFor(x => x.Request.UserName)
            .MinimumLength(1)
            .MaximumLength(30);

        RuleFor(x => x.Principal)
            .NotNull();
    }
}