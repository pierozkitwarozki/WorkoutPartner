using WorkoutPartner.Domain.Models;

namespace WorkoutPartner.Domain.DTO.Commands.ExerciseSchemaAdd;

public record ExerciseSchemaAddResponse(IEnumerable<ExerciseSchemaAddItemResponseModel> Schemas);
public record ExerciseSchemaAddItemResponseModel(
    IEnumerable<WeightWorkoutSet> Sets, 
    string Name, 
    string Schema, 
    Guid ExerciseId
    );