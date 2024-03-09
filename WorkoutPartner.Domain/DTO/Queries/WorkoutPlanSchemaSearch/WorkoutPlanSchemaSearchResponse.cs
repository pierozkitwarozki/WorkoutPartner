using WorkoutPartner.Domain.DTO.Queries.Paging;

namespace WorkoutPartner.Domain.DTO.Queries.WorkoutPlanSchemaSearch;

public record WorkoutPlanSchemaSearchResponse(
    bool ContainsMore, 
    IEnumerable<WorkoutPlanSchemaSearchItemResponseModel> Plans) : PageResponse(ContainsMore);

public record WorkoutPlanSchemaSearchItemResponseModel(
    Guid Id, 
    string Name, 
    string? Description, 
    DateTime CreatedAt
    );