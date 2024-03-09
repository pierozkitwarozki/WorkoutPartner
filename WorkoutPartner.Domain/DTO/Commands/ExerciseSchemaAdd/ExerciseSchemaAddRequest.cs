namespace WorkoutPartner.Domain.DTO.Commands.ExerciseSchemaAdd;

public record ExerciseSchemaAddRequest(
    IEnumerable<ExerciseSchemaAddItemRequestModel> Schemas
    );

public record ExerciseSchemaAddItemRequestModel(
    string Name, 
    string Schema, 
    Guid ExerciseId, 
    string? Description
    );
