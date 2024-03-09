using MediatR;
using WorkoutPartner.Domain.DTO.Queries.ExerciseSearch;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Queries;

public class ExerciseSearchQuery : IRequest<Result<ExerciseSearchResponse>>
{
    public required ExerciseSearchRequest Request { get; init; }
}