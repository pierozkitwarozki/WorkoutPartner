using WorkoutPartner.Domain.Models;

namespace WorkoutPartner.Domain.DTO.ExerciseSchemaAdd;

public record ExerciseSchemaAddResponse(IEnumerable<WeightWorkoutSet> Sets, string Name, string Schema, Guid ExerciseId);