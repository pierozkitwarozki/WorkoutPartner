namespace WorkoutPartner.Domain.DTO.ExerciseSchemaAdd;

public record ExerciseSchemaAddRequest(string Name, string Schema, Guid ExerciseId, string? Description);
