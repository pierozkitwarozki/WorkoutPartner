using FluentValidation;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.DTO.WorkoutPlanSchemaAdd;

namespace WorkoutPartner.Infrastructure.Validators.Commands;

public class WorkoutPlanSchemaAddCommandValidator : AbstractValidator<WorkoutPlanSchemaAddCommand>
{
    public WorkoutPlanSchemaAddCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Request.Description)
            .MaximumLength(1000);

        RuleFor(x => x.Request.Exercises)
            .NotNull()
            .NotEmpty();

        RuleForEach(x => x.Request.Exercises)
            .SetValidator(new WorkoutPlanSchemaAddItemRequestModelValidator());
    }
}

file class WorkoutPlanSchemaAddItemRequestModelValidator : AbstractValidator<WorkoutPlanSchemaAddItemRequestModel> 
{
    public WorkoutPlanSchemaAddItemRequestModelValidator()
    {
        RuleFor(x => x.Order)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.ExerciseSchemaId)
            .NotNull()
            .NotEmpty();
    }
}