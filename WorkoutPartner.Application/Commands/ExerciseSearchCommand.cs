using MediatR;
using WorkoutPartner.Domain.DTO.ExerciseSearch;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Commands;

public class ExerciseSearchCommand : IRequest<Result<ExerciseSearchResponse>>
{
    public required ExerciseSearchRequest Request { get; init; }
}