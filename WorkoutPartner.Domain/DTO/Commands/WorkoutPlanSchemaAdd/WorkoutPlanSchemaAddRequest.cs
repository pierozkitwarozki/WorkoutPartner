namespace WorkoutPartner.Domain.DTO.Commands.WorkoutPlanSchemaAdd;

public record WorkoutPlanSchemaAddRequest(
    string Name, 
    string? Description, 
    IEnumerable<WorkoutPlanSchemaAddItemRequestModel> Exercises
    );
public record WorkoutPlanSchemaAddItemRequestModel(
    Guid ExerciseSchemaId,
    int Order
    );