using MediatR;
using WorkoutPartner.Domain.DTO.Queries.WorkoutPlanSchemaSearch;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Queries;

public class WorkoutPlanSchemaSearchQuery : IRequest<Result<WorkoutPlanSchemaSearchResponse>>
{
    public required string? UserId { get; init; }
    public required WorkoutPlanSchemaSearchRequest Request { get; init; }
}