using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.ExerciseSchemaAdd;

namespace WorkoutPartner.Infrastructure.Mappers;

public static class ExerciseSchemaMapper
{
    public static ExerciseSchema MapToEntity(
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