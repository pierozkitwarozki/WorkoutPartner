using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.Commands.ExerciseAdd;
using WorkoutPartner.Infrastructure.Converters;

namespace WorkoutPartner.Infrastructure.Mappers;

internal static class ExerciseMapper
{
    internal static Exercise MapToEntity(
        ExerciseAddRequest request, 
        DateTime createdAt, 
        string ownerId
        )
    {
        return new Exercise
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            CreatedAt = createdAt,
            Name = request.Name,
            Type = request.Type,
            VideoUrl = request.VideoUrl,
            ImageUrl = request.ImageUrl,
            OwnerId = ownerId,
            BodyParts = request.BodyParts.ConvertToBodyParts()
        };
    }

    internal static ExerciseAddResponse MapFromEntity(Exercise exercise)
    {
        var equipment = exercise.ExerciseEquipments?
            .Select(e 
                => new KeyValuePair<Guid, string>(
                    e.EquipmentId, 
                    e.Equipment?.Name ?? string.Empty
                ))
            .ToDictionary();
        
        return new ExerciseAddResponse(
            exercise.Id,
            exercise.Name,
            exercise.Description,
            exercise.CreatedAt,
            exercise.Type,
            exercise.VideoUrl, 
            exercise.ImageUrl,
            exercise.OwnerId,
            equipment
        );

    }
}