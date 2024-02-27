namespace WorkoutPartner.Domain.DTO.WorkoutPlanSchemaAdd;

public record WorkoutPlanSchemaAddRequest(
    string Name, 
    string? Description, 
    IEnumerable<WorkoutPlanSchemaAddItemRequestModel> Exercises
    );
public record WorkoutPlanSchemaAddItemRequestModel(
    Guid ExerciseSchemaId,
    int Order
    );