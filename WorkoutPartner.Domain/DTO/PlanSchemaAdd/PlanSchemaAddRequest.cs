namespace WorkoutPartner.Domain.DTO.PlanSchemaAdd;

public record PlanSchemaAddRequest(
    string Name, 
    string? Description, 
    IEnumerable<PlanSchemaAddItemRequestModel> Exercises
    );
public record PlanSchemaAddItemRequestModel(
    Guid ExerciseSchemaId,
    int Order
    );