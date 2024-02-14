using WorkoutPartner.Domain.Database.Enums;

namespace WorkoutPartner.Domain.DTO.ExerciseAdd;

public record ExerciseAddResponse(
    Guid Id,
    string Name,
    string? Description,
    DateTime CreatedAt,
    ExerciseType Type,
    string? Url,
    IDictionary<Guid, string>? Equipment
    );