using WorkoutPartner.Domain.DTO.Queries.Paging;

namespace WorkoutPartner.Domain.DTO.Queries.WorkoutPlanSchemaSearch;

public record WorkoutPlanSchemaSearchRequest(
    string? Name, 
    int PageNumber, 
    int PageSize
    ) : PageRequest(PageNumber, PageSize);