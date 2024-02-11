using FluentValidation;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Domain.Database.Enums;

namespace WorkoutPartner.Infrastructure.Validators;

public class ExerciseAddValidator : AbstractValidator<ExerciseAddCommand>
{
    public ExerciseAddValidator()
    {
        RuleFor(x => x.Request)
            .NotNull();

        RuleFor(x => x.Request.Type)
            .IsInEnum();

        RuleFor(x => x.Request.Description)
            .MaximumLength(1000);

        RuleFor(x => x.Request.Url)
            .MaximumLength(1000);

        RuleFor(x => x.Request.Name)
            .MinimumLength(1)
            .MaximumLength(100);
        
        RuleFor(x => x.Request.EquipmentIds!.Count())
            .LessThanOrEqualTo(20)
            .OverridePropertyName("Equipment count")
            .When(x => x.Request.EquipmentIds is not null);
    }
}