using FluentValidation;
using WorkoutPartner.Application.Commands;

namespace WorkoutPartner.Infrastructure.Validators;

public class ExerciseSearchCommandValidator : AbstractValidator<ExerciseSearchCommand>
{
    public ExerciseSearchCommandValidator()
    {
        RuleFor(x => x.Request.PageSize)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.Request.PageNumber)
            .GreaterThanOrEqualTo(1);
    }
}