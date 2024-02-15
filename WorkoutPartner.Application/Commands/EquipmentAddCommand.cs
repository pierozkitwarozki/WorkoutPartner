using MediatR;
using WorkoutPartner.Domain.DTO.EquipmentAdd;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Commands;

public class EquipmentAddCommand : IRequest<Result<EquipmentAddResponse>>
{
    public required string? UserId { get; set; }
    public required EquipmentAddRequest Request { get; init; }
}