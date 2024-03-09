using System.Collections.Immutable;
using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.Commands.WorkoutPlanSchemaAdd;

namespace WorkoutPartner.Infrastructure.Mappers;

internal static class ExerciseSchemaWorkoutPlanSchemaMapper
{
    internal static IImmutableList<ExerciseSchemaWorkoutPlanSchema> MapToEntities(
        WorkoutPlanSchemaAddRequest request,
        Guid workoutPlanSchemaId,
        DateTime createdAt)
    {
        return request
            .Exercises
            .Select(exercise 
            => new ExerciseSchemaWorkoutPlanSchema
            {
                CreatedAt = createdAt,
                ExerciseSchemaId = exercise.ExerciseSchemaId,
                ExerciseOrder = exercise.Order,
                WorkoutPlanSchemaId = workoutPlanSchemaId
            })
            .ToImmutableList();
    }
}