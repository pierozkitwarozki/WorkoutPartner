using MediatR;
using WorkoutPartner.Domain.DTO.WorkoutPlanSchemaAdd;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Commands;

public class WorkoutPlanSchemaAddCommand : IRequest<Result<WorkoutPlanSchemaAddResponse>>
{
    public required string? UserId { get; set; }
    public required WorkoutPlanSchemaAddRequest Request { get; init; }
}