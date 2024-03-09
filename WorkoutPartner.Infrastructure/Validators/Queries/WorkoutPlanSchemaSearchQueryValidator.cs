using FluentValidation;
using WorkoutPartner.Application.Queries;

namespace WorkoutPartner.Infrastructure.Validators.Queries;

public class WorkoutPlanSchemaSearchQueryValidator : AbstractValidator<WorkoutPlanSchemaSearchQuery>
{
    public WorkoutPlanSchemaSearchQueryValidator()
    {
        RuleFor(x => x.Request)
            .NotNull();

        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();
    }
}