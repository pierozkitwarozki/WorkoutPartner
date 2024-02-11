using MediatR;
using WorkoutPartner.Domain.DTO.ExerciseAdd;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Commands;

public class ExerciseAddCommand : IRequest<Result<ExerciseAddResponse>>
{
    public required ExerciseAddRequest Request { get; init; }
}