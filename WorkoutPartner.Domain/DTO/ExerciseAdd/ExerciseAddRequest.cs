using WorkoutPartner.Domain.Database.Enums;

namespace WorkoutPartner.Domain.DTO.ExerciseAdd;

public record ExerciseAddRequest(
    string Name, 
    ExerciseType Type, 
    IEnumerable<Guid>? EquipmentIds, 
    string? Description, 
    string? VideoUrl,
    string? ImageUrl
    );