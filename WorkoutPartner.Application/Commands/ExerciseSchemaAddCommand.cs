using MediatR;
using WorkoutPartner.Domain.DTO.Commands.ExerciseSchemaAdd;
using WorkoutPartner.Domain.ResultType;

namespace WorkoutPartner.Application.Commands;

public class ExerciseSchemaAddCommand : IRequest<Result<ExerciseSchemaAddResponse>>
{
    public required string? UserId { get; init; }
    public required ExerciseSchemaAddRequest Request { get; init; }
}