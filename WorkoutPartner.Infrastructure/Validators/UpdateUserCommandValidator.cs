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
            .GreaterThanOrEqualTo(50)
            .LessThanOrEqualTo(300);

        RuleFor(x => x.Data.Weight)
            .GreaterThanOrEqualTo(20)
            .LessThanOrEqualTo(1000);

        RuleFor(x => x.Principal)
            .NotNull();
    }
}