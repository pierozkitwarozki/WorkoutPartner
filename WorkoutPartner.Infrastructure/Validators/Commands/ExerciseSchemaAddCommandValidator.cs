using FluentValidation;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.DTO.ExerciseSchemaAdd;

namespace WorkoutPartner.Infrastructure.Validators.Commands;

public class ExerciseSchemaAddCommandValidator : AbstractValidator<ExerciseSchemaAddCommand>
{
    public ExerciseSchemaAddCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull();

        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();

        RuleForEach(x => x.Request.Schemas)
            .SetValidator(new ExerciseSchemaAddItemRequestModelValidator());
    }
}

file class ExerciseSchemaAddItemRequestModelValidator : AbstractValidator<ExerciseSchemaAddItemRequestModel>
{
    public ExerciseSchemaAddItemRequestModelValidator()
    {
        RuleFor(x => x.Schema)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.ExerciseId)
            .NotNull()
            .NotEmpty();
    }
}