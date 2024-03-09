using FluentValidation;
using WorkoutPartner.Application.Queries;

namespace WorkoutPartner.Infrastructure.Validators.Queries;

public class ExerciseSearchQueryValidator : AbstractValidator<ExerciseSearchQuery>
{
    public ExerciseSearchQueryValidator()
    {
        RuleFor(x => x.Request.PageSize)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.Request.PageNumber)
            .GreaterThanOrEqualTo(1);
    }
}