using WorkoutPartner.Domain.Database.Enums;

namespace WorkoutPartner.Domain.DTO.ExerciseAdd;

public record ExerciseAddResponse(
    Guid Id,
    string Name,
    string? Description,
    DateTimeOffset CreatedAt,
    ExerciseType Type,
    string? Url,
    IDictionary<Guid, string>? Equipment
    );