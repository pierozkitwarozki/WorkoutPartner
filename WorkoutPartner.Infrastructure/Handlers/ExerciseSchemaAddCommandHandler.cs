using System.Collections.Immutable;
using MediatR;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Application.Services.Interfaces;
using WorkoutPartner.Domain.DTO.ExerciseSchemaAdd;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Domain.ResultType.Errors;
using WorkoutPartner.Infrastructure.Converters;
using WorkoutPartner.Infrastructure.Mappers;

namespace WorkoutPartner.Infrastructure.Handlers;

public class ExerciseSchemaAddCommandHandler(IExerciseSchemaRepository exerciseSchemaRepository, IDateTimeService dateTimeService)
    : IRequestHandler<ExerciseSchemaAddCommand, Result<ExerciseSchemaAddResponse>>
{
    public async Task<Result<ExerciseSchemaAddResponse>> Handle(ExerciseSchemaAddCommand request, CancellationToken cancellationToken)
    {
        var exerciseSets = 
            WeightWorkoutConverter.ConvertExerciseToSets(request.Request.Schema)
                .ToImmutableArray();

        if (!exerciseSets.Any())
        {
            return Result<ExerciseSchemaAddResponse>.Failure(
                    ValidationError.New(
                        ErrorCodes.BadSchema, 
                        "Provided schema could not be parsed."
                        )
                    );
        }

        var entity = ExerciseSchemaMapper.MapExerciseSchemaAddRequestToExerciseSchemaEntity(
            request.Request, request.UserId!, dateTimeService.Now());
        
        await exerciseSchemaRepository.AddAsync(entity);
        await exerciseSchemaRepository.SaveChangesAsync();

        return Result<ExerciseSchemaAddResponse>.Success(
            new ExerciseSchemaAddResponse(exerciseSets, request.Request.Name, entity.Schema, entity.ExerciseId));
    }
}