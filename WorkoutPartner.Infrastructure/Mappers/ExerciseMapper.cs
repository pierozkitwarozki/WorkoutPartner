using WorkoutPartner.Domain.Database.Models;
using WorkoutPartner.Domain.DTO.ExerciseAdd;

namespace WorkoutPartner.Infrastructure.Mappers;

public static class ExerciseMapper
{
    public static Exercise MapFromExerciseAddRequestToExerciseEntity(ExerciseAddRequest request, DateTime createdAt)
    {
        return new Exercise
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            CreatedAt = createdAt,
            Name = request.Name,
            Type = request.Type,
            Url = request.Url
        };
    }

    public static ExerciseAddResponse MapFromExerciseToExerciseAddResponse(Exercise exercise)
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
            exercise.Url, 
            equipment
        );

    }
}