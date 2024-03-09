using FluentValidation;
using WorkoutPartner.Application.Commands;

namespace WorkoutPartner.Infrastructure.Validators.Commands;

public class EquipmentAddCommandValidator : AbstractValidator<EquipmentAddCommand>
{
    public EquipmentAddCommandValidator()
    {
        RuleFor(x => x.Request.Name)
            .MinimumLength(1)
            .MaximumLength(100);

        RuleFor(x => x.Request.Description)
            .MaximumLength(1000);
        
        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();
    }
}