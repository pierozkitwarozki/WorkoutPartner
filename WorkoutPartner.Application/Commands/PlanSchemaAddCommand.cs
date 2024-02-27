using MediatR;
using WorkoutPartner.Domain.DTO.PlanSchemaAdd;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Commands;

public class PlanSchemaAddCommand : IRequest<Result<PlanSchemaAddResponse>>
{
    public required string? UserId { get; set; }
    public required PlanSchemaAddRequest Request { get; init; }
}