using FluentValidation;
using WorkoutPartner.Application.Commands;

namespace WorkoutPartner.Infrastructure.Validators;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Data)
            .NotNull();

        RuleFor(x => x.Data.Height)
            .GreaterThanOrEqualTo(30)
            .LessThanOrEqualTo(350);

        RuleFor(x => x.Data.Weight)
            .GreaterThanOrEqualTo(20)
            .LessThanOrEqualTo(1000);

        RuleFor(x => x.Data.UserName)
            .MinimumLength(1)
            .MaximumLength(30);

        RuleFor(x => x.Principal)
            .NotNull();
    }
}