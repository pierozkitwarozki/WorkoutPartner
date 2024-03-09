using MediatR;
using WorkoutPartner.Domain.DTO.Commands.EquipmentAdd;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Commands;

public class EquipmentAddCommand : IRequest<Result<EquipmentAddResponse>>
{
    public required string? UserId { get; init; }
    public required EquipmentAddRequest Request { get; init; }
}