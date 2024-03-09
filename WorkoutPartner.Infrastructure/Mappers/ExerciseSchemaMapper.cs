using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.Commands.ExerciseSchemaAdd;

namespace WorkoutPartner.Infrastructure.Mappers;

internal static class ExerciseSchemaMapper
{
    internal static ExerciseSchema MapToEntity(
        ExerciseSchemaAddItemRequestModel request, string userId, DateTime createdAt)
    {
        return new ExerciseSchema
        {
            CreatedAt = createdAt,
            Name = request.Name,
            UserId = userId,
            Schema = request.Schema,
            ExerciseId = request.ExerciseId,
            Description = request.Description,
            Id = Guid.NewGuid()
        };
    }
}