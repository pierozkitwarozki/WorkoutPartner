using FluentValidation;
using WorkoutPartner.Application.Commands;

namespace WorkoutPartner.Infrastructure.Validators;

public class ExerciseSchemaAddCommandValidator : AbstractValidator<ExerciseSchemaAddCommand>
{
    public ExerciseSchemaAddCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull();

        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Request.Schema)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Request.ExerciseId)
            .NotNull()
            .NotEmpty();
    }
}