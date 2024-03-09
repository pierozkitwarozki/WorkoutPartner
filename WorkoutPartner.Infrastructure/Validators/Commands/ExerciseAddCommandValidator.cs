using FluentValidation;
using WorkoutPartner.Application.Commands;

namespace WorkoutPartner.Infrastructure.Validators.Commands;

public class ExerciseAddCommandValidator : AbstractValidator<ExerciseAddCommand>
{
    public ExerciseAddCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull();

        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Request.Type)
            .IsInEnum();

        RuleFor(x => x.Request.Description)
            .MaximumLength(1000);

        RuleFor(x => x.Request.VideoUrl)
            .MaximumLength(1000);
        
        RuleFor(x => x.Request.ImageUrl)
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