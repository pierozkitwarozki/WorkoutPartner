using FluentValidation;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.DTO.PlanSchemaAdd;

namespace WorkoutPartner.Infrastructure.Validators;

public class PlanSchemaAddCommandValidator : AbstractValidator<PlanSchemaAddCommand>
{
    public PlanSchemaAddCommandValidator()
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
            .SetValidator(new PlanSchemaAddItemRequestModelValidator());
    }
}

file class PlanSchemaAddItemRequestModelValidator : AbstractValidator<PlanSchemaAddItemRequestModel> 
{
    public PlanSchemaAddItemRequestModelValidator()
    {
        RuleFor(x => x.Order)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.ExerciseSchemaId)
            .NotNull()
            .NotEmpty();
    }
}