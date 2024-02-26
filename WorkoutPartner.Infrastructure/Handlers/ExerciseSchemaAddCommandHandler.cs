using System.Collections.Immutable;
using MediatR;
using WorkoutPartner.Application.Commands;
using WorkoutPartner.Application.Repositories.Interfaces;
using WorkoutPartner.Application.Services.Interfaces;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.ExerciseSchemaAdd;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Domain.ResultType.Errors;
using WorkoutPartner.Domain.ResultType.Errors.Codes;
using WorkoutPartner.Infrastructure.Converters;
using WorkoutPartner.Infrastructure.Mappers;

namespace WorkoutPartner.Infrastructure.Handlers;

public class ExerciseSchemaAddCommandHandler(IExerciseSchemaRepository exerciseSchemaRepository, IDateTimeService dateTimeService)
    : IRequestHandler<ExerciseSchemaAddCommand, Result<ExerciseSchemaAddResponse>>
{
    public async Task<Result<ExerciseSchemaAddResponse>> Handle(ExerciseSchemaAddCommand request, CancellationToken cancellationToken)
    {
        var entities = new List<ExerciseSchema>();
        var results = new List<ExerciseSchemaAddItemResponseModel>();
        
        foreach (var schema in request.Request.Schemas)
        {
            var exerciseSets = 
                WeightWorkoutConverter
                    .ConvertExerciseToSets(schema.Schema)
                    .ToImmutableArray();

            // All schemas must be valid
            if (!exerciseSets.Any())
            {
                return Result<ExerciseSchemaAddResponse>.Failure(
                    ValidationError.New(
                        ValidationErrorCodes.BadSchema, 
                        "Provided schema could not be parsed."
                    )
                );
            }
            
            var entity = ExerciseSchemaMapper.MapToEntity(
                schema, 
                request.UserId!, 
                dateTimeService.Now()
                );
            
            entities.Add(entity);

            var result =
                new ExerciseSchemaAddItemResponseModel(exerciseSets, schema.Name, entity.Schema, entity.ExerciseId);
            
            results.Add(result);
        }
        
        await exerciseSchemaRepository.AddRangeAsync(entities);
        await exerciseSchemaRepository.SaveChangesAsync();

        return Result<ExerciseSchemaAddResponse>.Success(new ExerciseSchemaAddResponse(results));
    }
    
}